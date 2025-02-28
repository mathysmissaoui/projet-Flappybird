using UnityEngine;

public class PipeScoreTrigger : MonoBehaviour
{
    public LogicScript logic;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            logic.AddScore(1);
        }
    }
}
