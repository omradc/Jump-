using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float fallTime = 5;
    public float fallSpeed;
    public float destroyTime;
    bool timeToFall;
    void Start()
    {
        timeToFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToFall)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }

    }

    public IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallTime);
        timeToFall = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, destroyTime);
    }
}
