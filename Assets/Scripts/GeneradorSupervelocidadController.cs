using System.Collections;
using UnityEngine;

public class GeneradorSupervelocidadController : MonoBehaviour
{
    [SerializeField] public GameObject supervelocidadSpawneable;
    float minSpawnTime = 10f;
    float maxSpawnTime = 30f;
    float minx = -2.5f;
    float maxx = 2.5f;

    private bool isSpawning = false; // Indica si el generador está activo
    private bool isGameOver = false; // Nuevo: indica si el juego terminó

    private void SpawnSupervelocidad()
    {
        float randomX = Random.Range(minx, maxx);
        Vector2 spawnPos = new Vector2(randomX, transform.position.y);
        Instantiate(supervelocidadSpawneable, spawnPos, Quaternion.identity);
    }

    private IEnumerator SpawnCoroutine()
    {
        while (isSpawning)
        {
            // Esperar un tiempo aleatorio entre spawns
            float randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomSpawnTime);

            if (isGameOver) yield break; // Termina la corrutina si el juego acabó

            SpawnSupervelocidad();
        }
    }

    public void StartSpawning()
    {
        if (!isSpawning && !isGameOver) // No iniciar si el juego terminó
        {
            isSpawning = true;
            StartCoroutine(SpawnCoroutine());
        }
    }

    public void StopSpawning()
    {
        if (isSpawning)
        {
            isSpawning = false;
            StopAllCoroutines(); // Detenemos todas las corrutinas activas
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        supervelocidadSpawneable.GetComponent<Rigidbody2D>().gravityScale = 1f;

        // Iniciar el spawner sin spawnear inmediatamente
        StartSpawning();
    }
}
