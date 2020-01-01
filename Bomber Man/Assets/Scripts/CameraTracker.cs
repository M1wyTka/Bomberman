using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public Vector3 cameraOffset = new Vector3(0, 0, -10);
    public float moveTime = 1f;

    private List<Collider2D> enemiesInside = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enemiesInside.Contains(collision) && collision.CompareTag("Smart Enemy"))
            enemiesInside.Add(collision);

        if (collision.CompareTag("Player"))
        {
            StartCoroutine(MoveToPosition(GameObject.Find("Main Camera").transform, this.transform.position + cameraOffset, moveTime));
            AstarPath.active.data.gridGraph.center = transform.position;
            AstarPath.active.Scan();

            foreach(Collider2D col in enemiesInside)
                col.transform.GetComponent<AIPath>().canMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemiesInside.Contains(collision))
            enemiesInside.Remove(collision);

        if (collision.CompareTag("Player"))
            foreach (Collider2D col in enemiesInside)
                col.transform.GetComponent<AIPath>().canMove = false;
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
