using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 1f;
    private float timer = 0f;

    public float horizontalSpacing = 20f;
    private float spawnXPosition = 20f;

    private float minY;
    private float maxY;  

    void Start()
    {

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minY = bottomLeft.y + 2f;
        maxY = topRight.y - 2f;

        spawnPipe();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0f;
        }
    }

    void spawnPipe()
    {

        float spawnY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(spawnXPosition, spawnY, 0);

        Instantiate(pipe, spawnPosition, Quaternion.identity);

        spawnXPosition += horizontalSpacing;
    }
}