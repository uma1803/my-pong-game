using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
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

        if (Input.GetKey(KeyCode.W)) // Move up
        {
            playerMove.y = 1;
        }
        else if (Input.GetKey(KeyCode.S)) // Move down
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
        rb.linearVelocity = playerMove * movementSpeed; // Use velocity instead of linearVelocity
    }
}
