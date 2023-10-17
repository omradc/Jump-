using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public float jumpForce;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public float countDown;
    public float repeatCountDown;
    public float gravity;
    Vector3 force;
    Vector2 startMousePos;
    Vector2 lastMousePos;
    Vector2 direction;
    public GameObject platform;
    float distance;
    float score;
    float highScore;
    bool isGrounded;

    Indicator indicator;
    LevelDesigner levelDesigner;

    void Start()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        indicator = Indicator.instance;
        levelDesigner = LevelDesigner.instance;
        highScoreText.text = $"High: {PlayerPrefs.GetFloat("HighScore")}";
    }
    void Update()
    {
        if (isGrounded)
        {
            countDown = repeatCountDown;
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
        if (!isGrounded)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                GameOver();
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        if (collision.transform.tag == "Platform")
        {
            platform = collision.gameObject;
            StartCoroutine(platform.GetComponent<Platform>().Fall());
        }

        Score();
        levelDesigner.CreatePlatform();

    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Score()
    {
        score = transform.position.y - 50.5f;
        score = Mathf.Round(score);
        scoreText.text = $"{score}";

        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = $"High: {highScore}";
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
    }
}
