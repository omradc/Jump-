using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject cam;
    public float force;
    float distance;
    Vector2 posA;
    Vector2 posB;

    void Start()
    {
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posA = cam.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            //Game Mechanics
            posB = cam.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition);
            distance = Vector3.Distance(posA, posB);
            Vector2 direction = ((posB - posA) * -1).normalized;
            rb.AddForce(direction * distance * force, ForceMode.Impulse);
        }


    }




}
