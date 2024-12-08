using System.Collections;
using UnityEngine;

/// <summary>
/// Controlador para generar objetos de tipo Bonus en posiciones aleatorias.
/// Maneja el inicio, la detención y las condiciones relacionadas con el estado del juego.
/// </summary>
public class GeneradorBonusController : MonoBehaviour
{
    /// <summary>
    /// Prefab del objeto Bonus que será generado.
    /// Debe asignarse desde el Inspector.
    /// </summary>
    [SerializeField] public GameObject bonusSpawneable;

    /// <summary>
    /// Tiempo mínimo entre la aparición de Bonus.
    /// </summary>
    float minSpawnTime = 5f;

    /// <summary>
    /// Tiempo máximo entre la aparición de Bonus.
    /// </summary>
    float maxSpawnTime = 15f;

    /// <summary>
    /// Límite mínimo en el eje X para la posición de aparición.
    /// </summary>
    float minx = -2.5f;

    /// <summary>
    /// Límite máximo en el eje X para la posición de aparición.
    /// </summary>
    float maxx = 2.5f;

    /// <summary>
    /// Indica si el generador está activo.
    /// </summary>
    private bool isSpawning = false;

    /// <summary>
    /// Indica si el juego ha terminado.
    /// </summary>
    private bool isGameOver = false;

    /// <summary>
    /// Genera un objeto Bonus en una posición aleatoria dentro de los límites establecidos.
    /// </summary>
    private void SpawnBonus()
    {
        float randomX = Random.Range(minx, maxx);
        Vector2 spawnPos = new Vector2(randomX, transform.position.y);
        Instantiate(bonusSpawneable, spawnPos, Quaternion.identity);
    }

    /// <summary>
    /// Corrutina que controla el tiempo de aparición de los Bonus.
    /// Genera Bonus mientras el generador esté activo y el juego no haya terminado.
    /// </summary>
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

    /// <summary>
    /// Inicia la generación de Bonus si el generador no está ya activo y el juego no ha terminado.
    /// </summary>
    public void StartSpawning()
    {
        if (!isSpawning && !isGameOver) // No iniciar si el juego terminó
        {
            isSpawning = true;
            StartCoroutine(SpawnCoroutine());
        }
    }

    /// <summary>
    /// Detiene la generación de Bonus.
    /// Finaliza todas las corrutinas activas asociadas al generador.
    /// </summary>
    public void StopSpawning()
    {
        if (isSpawning)
        {
            isSpawning = false;
            StopAllCoroutines(); // Detenemos todas las corrutinas activas
        }
    }

    /// <summary>
    /// Lógica para manejar el final del juego.
    /// Marca el estado del juego como terminado y detiene la generación de Bonus.
    /// </summary>
    public void GameOver()
    {
        isGameOver = true; // Marca el juego como terminado
        StopSpawning();    // Detén el spawn si está en curso
    }

    /// <summary>
    /// Método llamado al inicio del ciclo de vida del objeto.
    /// Configura la física de los Bonus y comienza la generación de objetos.
    /// </summary>
    void Start()
    {
        bonusSpawneable.GetComponent<Rigidbody2D>().gravityScale = 1f;

        // Iniciar el spawner sin spawnear inmediatamente
        StartSpawning();
    }
}
