using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    #region Singelton
    public static Follow instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }
    #endregion

    [SerializeField] Transform target;
    [SerializeField] Vector3 delay;
    [SerializeField][Range(0, 1)] float smoothness=0.12f;


    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + delay;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,smoothness);
        transform.position = smoothedPosition;
    }




}
