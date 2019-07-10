using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text scoreText;
    public Text livesText;
    public Text winText;
    public Text loseText;
    public GameObject player;


    private Rigidbody rb;
    private int count;
    private int lives;
    private int score;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

            count = 0;
            score = 0;
            lives = 3;
            SetCountText ();
            SetScoreText ();
            SetLivesText ();

            winText.text = "";
            loseText.text = "";

    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void LateUpdate()
    {

        float moveHorizantal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizantal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText ();
            SetScoreText ();
        }

        if(other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1;
            lives = lives - 1;
            SetScoreText ();
            SetCountText ();
            SetLivesText ();
        }
        if(lives <= 0)
        {
            Destroy(player);
            loseText.text = "You lose";
        }
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
    }

    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString ();
    }

    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString ();
        if (score >= 23)
        {
            winText.text = "You Win";
        }
    }
}
