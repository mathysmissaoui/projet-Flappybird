using UnityEngine;
using UnityEngine.SceneManagement;

public class birdscript : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public float flapStrength = 5000f; // Declare flapStrength and set a default value
    public LogicScript logic; // Reference to LogicScript
    private bool birdIsAlive = true; // Track if bird is still alive

    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>(); // Ensure Rigidbody2D is assigned
        // Find the LogicScript in the scene
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        // Only allow flapping if bird is alive
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigibody.linearVelocity = Vector2.up * 7; // Fixed: using velocity instead of linearVelocity
        }
        
        // Check if bird is off screen (too high or too low)
        if (transform.position.y > 15 || transform.position.y < -15)
        {
            EndGame();
        }
    }
    
    // Called when bird collides with pipes or ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }
    
    // Handle game over
    void EndGame()
    {
        if (birdIsAlive)
        {
            birdIsAlive = false;
            // Stop the bird's movement
            myRigibody.linearVelocity = Vector2.zero;
            // Show game over screen
            logic.GameOver();
        }
    }
}