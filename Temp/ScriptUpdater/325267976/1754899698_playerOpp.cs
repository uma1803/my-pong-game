using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOpp : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playerMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();
        }
    }

    private void PlayerControl()
    {
        playerMove = new Vector2(0, 0); // Reset movement

        if (Input.GetKey(KeyCode.UpArrow)) // Move up
        {
            playerMove.y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) // Move down
        {
            playerMove.y = -1;
        }
    }

    private void AIControl()
    {
        if (ball.transform.position.y > transform.position.y + 0.5f)
        {
            playerMove = new Vector2(0, 1);
        }
        else if (ball.transform.position.y < transform.position.y - 0.5f)
        {
            playerMove = new Vector2(0, -1);
        }
        else
        {
            playerMove = new Vector2(0, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = playerMove * movementSpeed; // Use velocity for smooth movement
    }
}
