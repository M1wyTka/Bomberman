using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed = 0.01f;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, spinSpeed*Time.deltaTime);
    }
}
