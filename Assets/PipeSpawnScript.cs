using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2f;
    private float timer = 0f;

    public float horizontalSpacing = 20f;  // Espacement horizontal entre chaque paire de tuyaux
    private float spawnXPosition = 10f;    // Position horizontale initiale des tuyaux

    private float minY;  // Bord inférieur de la caméra (visible)
    private float maxY;  // Bord supérieur de la caméra (visible)

    void Start()
    {
        // Récupère les bords visible de la caméra
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minY = bottomLeft.y + 2f;  // Ajoute une marge pour ne pas coller au bord
        maxY = topRight.y - 2f;    // Idem pour le haut

        spawnPipe();  // Démarre avec un premier tuyau
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
            timer = 0f;  // Reset du timer
        }
    }

    void spawnPipe()
    {
        // Calcule une position verticale aléatoire mais limitée à l'écran visible
        float spawnY = Random.Range(minY, maxY);

        // Position de spawn avec la position X dynamique et la position Y contrôlée
        Vector3 spawnPosition = new Vector3(spawnXPosition, spawnY, 0);

        // Instancie le pipe
        Instantiate(pipe, spawnPosition, Quaternion.identity);

        // Avance la position X pour le prochain pipe (espacement horizontal)
        spawnXPosition += horizontalSpacing;
    }
}
