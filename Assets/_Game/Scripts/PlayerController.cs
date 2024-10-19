using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [field: SerializeField] public int id { get; set; }
    [SerializeField] private Transform Cannon;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject bullet;

    private Direction currentDir;
    private bool canAttack = true;
    private Vector3 mousePosDown;
    private Vector3 mousePosUp;
    private bool isTouch;
    private bool isMove = true;
    private float currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = 90;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void Fire()
    {
        GameObject bulletPlayer = Instantiate(bullet, Cannon.transform.position, this.transform.rotation);
        bulletPlayer.GetComponent<BaseBullet>().OnInit(Cannon.forward);
    }

    IEnumerator FireInterval()
    {
        canAttack = false;
        GameObject bulletPlayer = Instantiate(bullet, Cannon.transform.position, Cannon.transform.rotation);
        bulletPlayer.GetComponent<BaseBullet>().OnInit(Cannon.forward);
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }

    public override void Move()
    {
        if (Input.GetMouseButton(0))
        {
            isMove = false;
            if(canAttack)
            StartCoroutine(FireInterval());
        }
        if (!isMove) return;
        currentDir = GetDirection(Angle());
        switch (currentDir)
        {
            case Direction.Up:
                this.transform.rotation = Quaternion.LookRotation(Camera.main.transform.up);
                rb.velocity = Vector3.forward * speed;
                break;
            case Direction.Right:
                this.transform.rotation = Quaternion.LookRotation(Camera.main.transform.right);
                rb.velocity = Vector3.right * speed;
                break;
            case Direction.Left:
                this.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.right);
                rb.velocity = Vector3.left * speed;
                break;
            case Direction.Down:
                this.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.up);
                rb.velocity = Vector3.back * speed;
                break;
            default:
                break;
        }
    }

    private float Angle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosDown = Input.mousePosition;
            isTouch = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMove = true;
            mousePosUp = Input.mousePosition;
            Vector3 dir = mousePosUp - mousePosDown;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (angle != 0)
            {
                currentAngle = angle;
                return currentAngle;
            }
        }
        return currentAngle;
    }

    private Direction GetDirection(float angle)
    {
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
}

