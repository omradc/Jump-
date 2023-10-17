using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    public GameObject lastPlatform;
    public GameObject platformPrefab;
    public GameObject level;
    [Range(0f, 15f)] public float platformHigh;
    [Range(0f, 30f)] public float platformDistance;
    [Range(0f, 30f)] public float platformWidth;
    GameObject currentPlatform;
    float scaleX;
    float posX;
    float posY;
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            CreatePlatform();
        }
    }

    void Update()
    {



    }

    public void CreatePlatform()
    {
        currentPlatform = Instantiate(platformPrefab, lastPlatform.transform.position, transform.rotation);
        SetPlatformWidth(platformWidth);
        SetPlatformHighAndDistnace(platformDistance, platformHigh);
        lastPlatform = currentPlatform;
        currentPlatform.transform.SetParent(level.transform);
    }


    void SetPlatformWidth(float width)
    {
        scaleX = Random.Range(1, width);
        currentPlatform.transform.localScale = new Vector3(scaleX, 30, 2);
    }
    void SetPlatformHighAndDistnace(float distnace, float high)
    {
        posX = Random.Range(0, distnace);
        posY = Random.Range(1, high);
        currentPlatform.transform.position += new Vector3(posX, posY, 0);
    }



}
