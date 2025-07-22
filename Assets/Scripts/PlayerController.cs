using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private float jumpForce = 5f;
    public GameObject loseScreenUI;
    public int score, hiScore; // Variable to hold the player's score
    public Text scoreText, hiScoreText; // UI Text to display the score
    string HISCORE = "HISCORE"; // Key for PlayerPrefs to store high score

    private void Awake()
    {
        // Initialize the Rigidbody2D component  
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created  
    void Start()
    {
        hiScore = PlayerPrefs.GetInt(HISCORE); // Retrieve the high score from PlayerPrefs, defaulting to 0 if not set 

    }

    // Update is called once per frame  
    void Update()
    {
        PlayerJump();
    }

    void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.singleton.PlaySound(0);
            rb.linearVelocity = Vector2.up * jumpForce; // Updated to use linearVelocity instead of velocity  
            print("Jumping with force");
        }
    }

    void PlayerLose()
    {
        AudioManager.singleton.PlaySound(1);
        if (score > hiScore) // Check if the current score is greater than the high score
        {
            hiScore = score; // Store the current score as high score
            PlayerPrefs.SetInt(HISCORE, hiScore); // Save the high score to PlayerPrefs 
        }
        
        hiScoreText.text = "High Score: " + hiScore.ToString(); // Update the high score UI text
        loseScreenUI.SetActive(true); // Show the lose screen UI
        Time.timeScale = 0; // Stop the game when the player loses
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene to restart the game
    }

    void AddScore()
    {
        AudioManager.singleton.PlaySound(2); // Play the score sound using AudioManager
        score++; // Increment the score by 1
        scoreText.text = score.ToString(); // Update the score UI text
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            PlayerLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("score"))
        {
            AddScore();
        }
    }
}