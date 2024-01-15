using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D squarePlayer;
    public float gravityForceValue = 2f;
    public float playerSpeed = 0.5f;
    public float jumpForce = 10f;
    public bool isGround = false;
    public int gravDir = 1;
    public int coinCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGround = true;
        }
        if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.tag == "goal")
        {
            if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings -1))
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            coinCount++;
            Debug.Log("No. of coins collected = " + coinCount);
            Destroy(collision.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gravDir == 1)
            squarePlayer.gravityScale = gravityForceValue;
        else
            squarePlayer.gravityScale = -gravityForceValue;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Up
        if (Input.GetKeyDown(KeyCode.W))
        {
            squarePlayer.gravityScale = -gravityForceValue;
            isGround = false;
            gravDir = -1;
        }

        // Move Down
        if (Input.GetKeyDown(KeyCode.S))
        {
            squarePlayer.gravityScale = gravityForceValue;
            isGround = false;
            gravDir = 1;
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && (isGround == true))
        { 
            squarePlayer.AddForce(new Vector2(0, gravDir * jumpForce), ForceMode2D.Impulse);
            isGround = false;
        }
    }

    private void FixedUpdate()
    {
        squarePlayer.velocity = new Vector2(playerSpeed, squarePlayer.velocity.y);
    }
}
