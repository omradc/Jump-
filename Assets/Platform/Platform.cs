using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float gameDifficulty;
    public float fallSpeed;
    public bool timeToFall;
    void Start()
    {
        timeToFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToFall)
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

   public IEnumerator Fall()
    {
        yield return new WaitForSeconds(gameDifficulty);
        timeToFall = true;
        print("ok");
    }
}
