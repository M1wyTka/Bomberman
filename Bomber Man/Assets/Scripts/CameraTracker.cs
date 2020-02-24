using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public Vector3 cameraOffset = new Vector3(0, 0, -10);
    public float moveTime = 1f;

    public GameObject mapIcon;

    public GameObject scenery = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(MoveToPosition(GameObject.Find("Main Camera").transform, this.transform.position + cameraOffset, moveTime));
            AstarPath.active.data.gridGraph.center = transform.position;
            AstarPath.active.Scan();
            mapIcon.SetActive(true);
            scenery.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            scenery.SetActive(false);
        }
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
    }
}
