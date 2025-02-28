using UnityEngine;
using UnityEngine.SceneManagement;

public class birdscript : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public float flapStrength = 5000f; // Declare flapStrength and set a default value

    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>(); // Ensure Rigidbody2D is assigned
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigibody.linearVelocity = Vector2.up * 7; // Use 'velocity' instead of 'linearVelocity'
        }
    }
}
