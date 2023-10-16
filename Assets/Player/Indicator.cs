using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    #region Singelton
    public static Indicator instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }
    #endregion

    [SerializeField] GameObject child;
    [SerializeField] Transform playerPos;

    [Header("TRAJECTORY")]
    LineRenderer lineRenderer;
    public int linePoints = 175;
    public float time›nterval›nPoints = 0.01f;

    private void Start()
    {
        Hide();
        lineRenderer = child.GetComponent<LineRenderer>();
    }
    private void Update()
    {
        transform.position = playerPos.position;
    }
    public void Stick(float extendAmount, Vector3 direction)
    {
        child.transform.localScale = new Vector3(1, extendAmount, 1);
        child.transform.rotation = Quaternion.LookRotation(direction);
    }

    public void DrawTrajectory(Vector3 _force)
    {
        Vector3 origin = playerPos.position;
        Vector3 force = _force;
        lineRenderer.positionCount = linePoints;
        float time = 0;

        for (int i = 0; i < linePoints; i++)
        {
            var x = (force.x * time) + Physics.gravity.x / 2 * time * time;
            var y = (force.y * time) + Physics.gravity.y / 2 * time * time;

            Vector3 point = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, origin + point);
            time += time›nterval›nPoints;
        }
    }
    public void Show()
    {
        child.SetActive(true);
    }

    public void Hide()
    {
        child.SetActive(false);
    }
}
