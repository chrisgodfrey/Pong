using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public float speed = 30;
    public int p1Score = 0;
    public int p2Score = 0;
    public GameObject playerOneScore;
    public GameObject playerTwoScore;
    public GameObject gameManager;
    public AudioSource paddleHit;
    public AudioSource wallHit;
    public AudioSource gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void FixedUpdate()
    {
        if (speed > 40) 
        {
            speed = 30;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            // play the sound
            paddleHit.Play();
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            // play the sound
            paddleHit.Play();
        }

        // Hit the right Wall?
        if (col.gameObject.name == "WallRight")
        {

            // increase score
            p1Score += 1;
            Debug.Log("Player 1 Score: " + p1Score);
            playerOneScore.GetComponent<TextMeshProUGUI>().text = "" + p1Score;

            // has the player won?
            if (p1Score > 4)
            {
                Debug.Log("Player 1 won the game!");

                // play the sound
                gameOver.Play();

                gameManager.GetComponent<GameManager>().EndGame();
            }
            else
            {
                // play the sound
                wallHit.Play();
            }
        }

        // Hit the left Wall?
        if (col.gameObject.name == "WallLeft")
        {
            // increase score
            p2Score += 1;
            Debug.Log("Player 2 Score: " + p2Score);
            playerTwoScore.GetComponent<TextMeshProUGUI>().text = "" + p2Score;

            // has the player won?
            if (p2Score > 4)
            {
                Debug.Log("Player 2 won the game!");

                // play the sound
                gameOver.Play();

                gameManager.GetComponent<GameManager>().EndGame();
            }
            else
            {
                // play the sound
                wallHit.Play();
            }
        }
    }
}
