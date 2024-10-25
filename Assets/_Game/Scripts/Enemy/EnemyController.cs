using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseCharacter
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] public CheckBox checkBox;
    [SerializeField] public Transform bulletSpawn;
    [SerializeField] private Animator anim;
    [SerializeField] private TypeBullet typeBullet;
    [SerializeField] private GameObject frozenEffect;
    private BaseBullet bullet;
    public Vector3 randomDirection { get; set; }
    public float fireDelayTime;
    public float moveDelayTime;
    public float bulletTimeDisable;  
    private IState<EnemyController> currentState;
    public RunState runState;
    public FireState fireState;
    private Vector3[] direction = new Vector3[] {Vector3.back, Vector3.forward, Vector3.left, Vector3.right };
    private Coroutine move;
    private Coroutine bullets;
    private Coroutine frozenTime;
    private void Start()
    {
        fireState = new FireState();
        runState = new RunState();
        currentState = fireState;
    }
    private void Update()
    {
        StateControl();
        Frozen();
    }
    protected void StateControl()
    {
        if(currentState != null)
            currentState.OnExecute(this);
    }
    private IEnumerator DelayToMove()
    {
        yield return new WaitForSeconds(0.3f);  
        Move();
    }
    public override void Move()
    {
        float randomSpeed = Random.Range(3, 4);
        rb.velocity = randomDirection * randomSpeed * moveSpeed;
        anim.SetFloat(Const.runParaname, 0.2f);
    }
    public void ResetMove()
    {
        if (checkBox.isTouched)
        {
            Vector3 newRandom;
            do
            {
                newRandom = direction[Random.Range(0, direction.Length)];
            } while (newRandom == randomDirection);
            randomDirection = newRandom;
            transform.rotation = Quaternion.LookRotation(randomDirection);
            rb.velocity = Vector3.zero;
            StartCoroutine(DelayToMove());
        }
    }
    public void Rotate(Vector3 randomPosition)
    {
        randomPosition = direction[Random.Range(0, direction.Length)];
        randomDirection = randomPosition;
        transform.rotation = Quaternion.LookRotation(randomDirection);
        rb.velocity = Vector3.zero;
        StartCoroutine(DelayToMove());
    }
    
    public override void Fire()
    {
        bullet = SimplePool.Spawn<BaseBullet>(GetPoolTypeByBulletType());
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.rotation = bulletSpawn.rotation;
        bullet.OnInit(transform.forward,dame);
        rb.velocity = Vector3.zero;
        anim.SetFloat(Const.runParaname, 0f);
        anim.SetTrigger(Const.shotParame);
        bullets = StartCoroutine(DespawnBulelt());
        shotEffect.Play();
    }
    private PoolType GetPoolTypeByBulletType()
    {
        if(typeBullet == TypeBullet.Solider)
            return PoolType.bulletSolider;
        return PoolType.bulletEnenmy;
    }
    protected void Frozen()
    {
        if (UiBonnus.Instance.isFrozen)
        {
            rb.velocity = Vector3.zero;
            frozenEffect.SetActive(true);
            this.enabled = false;
            frozenTime = StartCoroutine(DeFrozen());
        }
        else return;
    }
    protected IEnumerator DeFrozen()
    {
        yield return new WaitForSeconds(10);
        frozenEffect.SetActive(false);
        ResetMove();
        UiBonnus.Instance.isFrozen = false;
        this.enabled = true;
        StopCoroutine(frozenTime);
    }
    private IEnumerator DespawnBulelt()
    {
        yield return new WaitForSeconds(bulletTimeDisable);
        SimplePool.Despawn(bullet);
        StopCoroutine(bullets);
    }
    public void ChangeState(IState<EnemyController> newState)
    {
        if(currentState != null)
            currentState.OnExit(this);
        currentState = newState;
        if(currentState != null)
            currentState.OnEnter(this);
    }
    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.CompareTag(Const.bulletPlayerTag))
        {
            Effect();
        }
    }
}
