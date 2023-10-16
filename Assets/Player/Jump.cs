using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public float jumpForce;
    public float timeToJump = 0.5f;

    Vector3 force;
    Vector2 startMousePos;
    Vector2 lastMousePos;
    Vector2 direction;
    float distance;
    bool isGrounded;

    Indicator indicator;


    void Start()
    {
        indicator = Indicator.instance;
    }
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startMousePos = cam.ScreenToViewportPoint(Input.mousePosition);
                indicator.Show();
            }

            if (Input.GetMouseButton(0))
            {
                lastMousePos = cam.ScreenToViewportPoint(Input.mousePosition);
                distance = Vector3.Distance(startMousePos, lastMousePos);
                direction = ((lastMousePos - startMousePos) * -1).normalized;
                force = direction * distance * jumpForce;

                indicator.DrawTrajectory(force);
            }

            if (Input.GetMouseButtonUp(0))
            {
                rb.AddForce(force, ForceMode.Impulse);
                indicator.Hide();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine("WaitForJump");
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(timeToJump);
        isGrounded = true;
    }

}
