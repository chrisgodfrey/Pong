using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRacket : MonoBehaviour
{
    public float speed = 30;
    public GameObject ball;

    void Update()
    {
        float v;
        if (ball.transform.position.y > (GetComponent<Rigidbody2D>().transform.position.y + GetComponent<Collider2D>().bounds.size.y))
        {
            v = 1;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
        }
        else if (ball.transform.position.y < (GetComponent<Rigidbody2D>().transform.position.y - GetComponent<Collider2D>().bounds.size.y))
        {
            v = -1;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
        }
    }
}
