using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    [SerializeField] private GameObject effectHit;
    private Coroutine walls;
    private void OnTriggerEnter(Collider wall)
    {
        if (wall.CompareTag(Const.bulletTag) || wall.CompareTag(Const.bulletPlayerTag))
        {
            GameObject effect = Instantiate(effectHit, wall.transform.position,wall.transform.rotation);
            //effectHit.transform.SetParent(this.transform);
            Destroy(effect,1f);
            walls = StartCoroutine(DisableWall());
        }
    }
    private IEnumerator DisableWall()
    {
        yield return new WaitForEndOfFrame();
        Transform brick = transform.parent;
        brick.gameObject.SetActive(false);
        StopCoroutine(walls);
    }
}
