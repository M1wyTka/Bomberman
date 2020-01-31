using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassNeedle : MonoBehaviour
{

    private GameObject northPole;
    private GameObject southPole;

    private bool isRotating = false;

    void Start()
    {
        Invoke("FindPoles", 1f);
    }

    private void FindPoles()
    {
        northPole = GameObject.FindGameObjectWithTag("Level Exit");
        southPole = GameObject.FindGameObjectWithTag("Player");
        isRotating = true;
    }

    void Update()
    {
        if (isRotating)
        {
            Vector3 rotation = (northPole.transform.position - southPole.transform.position);
            float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = new Quaternion(0, 0, angle, 1);
        }
           
    }
}
