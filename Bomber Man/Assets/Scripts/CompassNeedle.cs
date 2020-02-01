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
        Invoke("FindPoles", 5f);
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
            Vector3 lookPos = (northPole.transform.position - southPole.transform.position);
            var rotation = Quaternion.LookRotation(lookPos, Vector3.back) * Quaternion.Euler(90, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.05f);
        }
        else transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.Euler(0, 0, 90), 0.05f);
    }
}
