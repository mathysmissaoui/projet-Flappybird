using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 15f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}