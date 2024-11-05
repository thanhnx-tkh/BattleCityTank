using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Rigidbody playerRB;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject tutorialHand;
    [SerializeField] private TypeBullet typeBullet;
    [SerializeField] private Transform pointFire;
    [SerializeField] private GameObject fireWork;
    [SerializeField] private AudioSource audioBG;
    int index = 0;
    private Vector3 mousePosDown;
    private Vector3 mousePosUp;
    private bool isMove = true;
    private int moveSpeed = 5;
    private Vector3 dir = Vector3.zero;
    private bool canInteract = true;
    float dame = 1;
    private BaseBullet prefabBullet;
    public bool canFire = true;

    private float distanceY;
    private float distanceX;


    // Start is called before the first frame update
    void Start()
    {
        tutorialHand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePosition();
        CheckTutorial();
    }

    private void FixedUpdate()
    {
        if (!isMove)
            return;
        playerRB.velocity = dir * moveSpeed;
    }

    private void CheckTutorial()
    {
        if (!canInteract)
            return;
        switch (index)
        {
            case 0:
                // Up
                if (mousePosDown.y < mousePosUp.y && distanceY > 300f)
                {
                    dir = Vector3.forward;
                    HideTutorial(tutorial);
                    index += 1;
                }
                break;
            case 1:
                // Shot
                tutorialHand.GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main, playerTransform.position);
                StartCoroutine(ShowTutorial(tutorialHand));
                if (mousePosDown == mousePosUp && canInteract)
                {
                    Shoot();
                    HideTutorial(tutorialHand);
                    index += 1;
                    Debug.Log(tutorialHand.activeSelf + "1");
                }
                Debug.Log(tutorialHand.activeSelf);
                break;
            case 2:
                Debug.Log(tutorialHand.activeSelf + "2");
                Debug.Log(tutorialHand.gameObject.name + "3");
                //Down
                tutorial.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 180);
                StartCoroutine(ShowTutorial(tutorial));
                if (mousePosDown.y > mousePosUp.y && distanceY > 300f && canInteract)
                {
                    playerTransform.rotation = Quaternion.Euler(0, 180, 0);
                    dir = Vector3.back;
                    HideTutorial(tutorial);
                    index += 1;
                }
                break;
            case 3:

                // Left
                tutorial.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
                StartCoroutine(ShowTutorial(tutorial));
                if (mousePosDown.x > mousePosUp.x && distanceX > 300f && canInteract)
                {
                    playerTransform.rotation = Quaternion.Euler(0, -90, 0);
                    dir = Vector3.left;
                    HideTutorial(tutorial);
                    index += 1;
                }

                break;
            case 4:
                tutorial.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, -90);
                StartCoroutine(ShowTutorial(tutorial));
                if (!canInteract)
                    return;
                if (mousePosDown.x < mousePosUp.x && distanceX > 300f)
                {
                    HideTutorial(tutorial);
                    playerTransform.rotation = Quaternion.Euler(0, 90, 0);
                    dir = Vector3.right;
                    index += 1;
                }
                break;
            default:
                StartCoroutine(FinishTutorial());
                break;
        }
    }

    private void GetMousePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosDown = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mousePosUp = Input.mousePosition;
        }
        distanceY = Math.Abs(mousePosUp.y - mousePosDown.y);
        distanceX = Math.Abs(mousePosUp.x - mousePosDown.x);
    }

    private void HideTutorial(GameObject gTutorial)
    {
        if (gTutorial.activeSelf)
        {
            gTutorial.SetActive(false);
        }
    }

    private IEnumerator ShowTutorial(GameObject gTutorial)
    {
        if (gTutorial.activeSelf) 
            yield break;
        canInteract = false;
        yield return new WaitForSeconds(3f);
        gTutorial.SetActive(true);
        canInteract = true;
    }

    private void Shoot()
    {
        prefabBullet = SimplePool.Spawn<BaseBullet>(PoolType.bulletPlayer);
        prefabBullet.transform.position = pointFire.position;
        prefabBullet.transform.rotation = Quaternion.LookRotation(dir);
        prefabBullet.OnInit(dir, dame);
    }
    IEnumerator FinishTutorial()
    {
        fireWork.SetActive(true);
        audioBG.Stop();
        DataManager.Ins.SetTheFirstTimePlay(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SceneMain");
    }
}
