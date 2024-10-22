using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public enum Direction
{
    Right,
    Left,
    Up,
    Down,
    None
}
public class PlayerController : BaseCharacter
{
    [field: SerializeField] public int Id { get; set; }
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TypeBullet typeBullet;
    [SerializeField] private Transform pointFire;
    [SerializeField] private Animator anim;
    private BaseBullet prefabBullet;
    private Vector3 mousePosDown;
    private Vector3 mousePosUp;
    private Vector3 directionMove;
    private bool isMoving = true;
    private bool canFire = true;
    private float angle;
    private void Start()
    {
        directionMove = Vector3.forward * moveSpeed;
    }
    private void Update()
    {
        HandleAnimations();
        GetDirectionMoving();

    }
    private void FixedUpdate()
    {
        if (isMoving)
            Move();
    }

    //private void OnDrawGizmosSelected()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    pointFire = GetComponentInChildrenByName<Transform>("FireTransform");
    //    anim = GetComponentInChildrenByName<Animator>("Tank");
    //    shotEffect = GetComponentInChildrenByName<ParticleSystem>("WFX_Explosion Small_0");
    //}
    //public T GetComponentInChildrenByName<T>(string childName) where T : Component
    //{
    //    T[] components = GetComponentsInChildren<T>();

    //    foreach (T component in components)
    //    {
    //        if (component.gameObject.name == childName)
    //        {
    //            return component;
    //        }
    //    }

    //    return null;
    //}
    public override void Move()
    {
        rb.velocity = directionMove * moveSpeed;
        anim.SetFloat(Const.runParaname, 0.2f);
    }
    public void GetDirectionMoving()
    {
        Angle();
        Direction currentDir = GetDirection();

        switch (currentDir)
        {
            case Direction.Up:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                directionMove = Vector3.forward * moveSpeed;
                break;
            case Direction.Right:
                transform.rotation = Quaternion.Euler(0, 90, 0);
                directionMove = Vector3.right * moveSpeed;
                break;
            case Direction.Left:
                transform.rotation = Quaternion.Euler(0, -90, 0);
                directionMove = Vector3.left * moveSpeed;
                break;
            case Direction.Down:
                transform.rotation = Quaternion.Euler(0, 180, 0);
                directionMove = Vector3.back * moveSpeed;
                break;
            case Direction.None:
                break;
            default:
                break;
        }
    }
    private void Angle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = false;
            mousePosDown = Input.mousePosition;
            rb.velocity = Vector3.zero;
            anim.SetFloat(Const.runParaname, 0f);

        }
        if (Input.GetMouseButton(0))
        {
            if (canFire)
                StartCoroutine(Shoot());

            mousePosUp = Input.mousePosition;
            Vector3 directionVector = mousePosUp - mousePosDown;
            if (directionVector.magnitude < 2f)
            {
                this.angle = 1000;
            }
            else
            {
                this.angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = true;
        }
    }

    private Direction GetDirection()
    {
        if (angle == 1000) return Direction.None;
        if (angle >= 45 && angle < 135)
        {
            return Direction.Up;
        }
        else if (angle >= -45 && angle < 45 && angle != 0)
        {
            return Direction.Right;
        }
        else if (angle >= 135 || angle < -135)
        {
            return Direction.Left;
        }
        else if (angle >= -135 && angle < -45)
        {
            return Direction.Down;
        }
        else
        {
            return Direction.None;
        }
    }
    public IEnumerator Shoot()
    {
        canFire = false;
        yield return new WaitForSeconds(attackSpeed * 0.2f);
        anim.SetTrigger(Const.shotParame);
        shotEffect.Play();
        prefabBullet = SimplePool.Spawn<BaseBullet>(PoolType.bulletPlayer);

        prefabBullet.transform.position = pointFire.position;
        prefabBullet.transform.rotation = Quaternion.LookRotation(directionMove);
        prefabBullet.OnInit(directionMove,dame);

        yield return new WaitForSeconds(attackSpeed * 0.8f);
        canFire = true;
    }

    public void StopMoving()
    {
        rb.velocity = Vector3.zero;
        isMoving = false;
    }

    private void HandleAnimations()
    {
        float speedValue = rb.velocity.magnitude;

        anim.SetFloat(Const.runParaname, speedValue);

        if (speedValue > 0.1f)
        {
            anim.SetFloat("run", 1.0f);
        }
        else
        {
            anim.SetFloat("run", 0.0f);
        }
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag(Const.bulletTag))
        {
            Effect();
        }
    }
}