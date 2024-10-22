using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    [SerializeField] private GameObject effectHit;
    [SerializeField] private AudioSource hitSound;
    private Coroutine walls;
    private void Start()
    {
        hitSound = GameObject.FindGameObjectWithTag("HitSound").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider wall)
    {
        if (wall.CompareTag(Const.bulletTag) || wall.CompareTag(Const.bulletPlayerTag))
        {
            GameObject effect = Instantiate(effectHit, wall.transform.position,wall.transform.rotation);
            //effectHit.transform.SetParent(this.transform);
            Destroy(effect,1f);
            walls = StartCoroutine(DisableWall());
            hitSound.Play();
        }
    }
    private IEnumerator DisableWall()
    {
        yield return new WaitForEndOfFrame();
        Transform brick = transform.parent;
        Transform[] allBricks = brick.GetComponentsInChildren<Transform>();

        // Lấy tất cả các đối tượng con, nhưng bỏ qua chính brick
        List<Transform> brickChildren = new List<Transform>();
        foreach (Transform child in allBricks)
        {
            if (child != brick)
            {
                brickChildren.Add(child);
            }
        }
        int random = Random.Range(1, brickChildren.Count);
        for (int i = 0; i < random; i++)
        {
            brickChildren[i].gameObject.SetActive(false);
        }
        StopCoroutine(walls);
    }
}
