using System.Collections;
using UnityEngine;

public class GeneradorBonusController : MonoBehaviour
{
    [SerializeField] public GameObject bonusSpawneable;
    float minSpawnTime = 5f;
    float maxSpawnTime = 15f;
    float minx = -2.5f;
    float maxx = 2.5f;

    private bool isSpawning = false; // Indica si el generador está activo
    private bool isGameOver = false; // Nuevo: indica si el juego terminó

    private void SpawnBonus()
    {
        float randomX = Random.Range(minx, maxx);
        Vector2 spawnPos = new Vector2(randomX, transform.position.y);
        Instantiate(bonusSpawneable, spawnPos, Quaternion.identity);
    }

    private IEnumerator SpawnCoroutine()
    {
        while (isSpawning)
        {
            // Esperar un tiempo aleatorio entre spawns
            float randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomSpawnTime);

            if (isGameOver) yield break; // Termina la corrutina si el juego acabó

            SpawnBonus();
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

    public void GameOver()
    {
        isGameOver = true; // Marca el juego como terminado
        StopSpawning();    // Detén el spawn si está en curso
    }

    // Start is called before the first frame update
    void Start()
    {
        bonusSpawneable.GetComponent<Rigidbody2D>().gravityScale = 1f;

        // Iniciar el spawner sin spawnear inmediatamente
        StartSpawning();
    }
}
