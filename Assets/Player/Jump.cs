using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject cam;
    public float force;
    float distance;
    Vector2 startMousePos;
    Vector2 lastMousePos;
    Vector2 currentMousePos;
    Vector2 direction;

    public LineRenderer lineRenderer;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = cam.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition);
        }
        //if (Input.GetMouseButton(0))
        //{
        //    currentMousePos = cam.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition);
        //    print(currentMousePos);
        //}
        if (Input.GetMouseButtonUp(0))
        {
            lastMousePos = cam.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition);
            distance = Vector3.Distance(startMousePos, lastMousePos);
            direction = ((lastMousePos - startMousePos) * -1).normalized;
            rb.AddForce(direction * distance * force, ForceMode.Impulse);
        }
    }

    void DrawLine()
    {
        lineRenderer.SetPosition(0, transform.position);
    }

}
