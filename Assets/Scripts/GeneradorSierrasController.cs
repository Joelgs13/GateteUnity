using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador para generar objetos de tipo Sierra en posiciones aleatorias.
/// Gestiona la velocidad de aparición, la dificultad progresiva, y la detención del generador.
/// </summary>
public class GeneradorSierrasController : MonoBehaviour
{
    /// <summary>
    /// Prefab del objeto Sierra que será generado.
    /// Debe asignarse desde el Inspector.
    /// </summary>
    [SerializeField] public GameObject sierraSpawneable;

    /// <summary>
    /// Velocidad inicial entre las apariciones de las sierras (en segundos).
    /// </summary>
    [SerializeField] float velocidadSpawn = 2f;

    /// <summary>
    /// Límite mínimo en el eje X para la posición de aparición de las sierras.
    /// </summary>
    float minx = -2.5f;

    /// <summary>
    /// Límite máximo en el eje X para la posición de aparición de las sierras.
    /// </summary>
    float maxx = 2.5f;

    /// <summary>
    /// Contador de sierras generadas, usado para controlar la dificultad progresiva.
    /// </summary>
    int contador = 0;

    /// <summary>
    /// Relación entre el contador de sierras y el tiempo necesario para aumentar la dificultad.
    /// </summary>
    float proporcionDelContadorFrenteATempo = 10;

    /// <summary>
    /// Genera una sierra en una posición aleatoria dentro de los límites y ajusta la dificultad progresiva.
    /// </summary>
    void SpawnSierras()
    {
        print("inv");

        // Generar una posición aleatoria para la sierra
        float randomX = Random.Range(minx, maxx);
        Vector2 spawnPos = new Vector2(randomX, transform.position.y);

        // Instanciar la sierra en la posición generada
        Instantiate(sierraSpawneable, spawnPos, Quaternion.identity);
        contador++;

        // Ajustar la dificultad cuando se alcanza el límite definido
        if (contador >= proporcionDelContadorFrenteATempo)
        {
            // Aumentar la velocidad de spawn
            velocidadSpawn *= 0.9f;

            // Incrementar el umbral para la siguiente dificultad
            proporcionDelContadorFrenteATempo *= 1.1f;

            // Reiniciar el contador
            contador = 0;

            // Aumentar la gravedad de las sierras
            sierraSpawneable.GetComponent<Rigidbody2D>().gravityScale *= 1.1f;

            // Reiniciar el intervalo de aparición con la nueva velocidad
            CancelInvoke();
            StartSpawning();
        }
    }

    /// <summary>
    /// Inicia el proceso de generación repetitiva de sierras.
    /// </summary>
    void StartSpawning()
    {
        InvokeRepeating("SpawnSierras", 1f, velocidadSpawn);
    }

    /// <summary>
    /// Detiene el proceso de generación de sierras.
    /// </summary>
    public void StopSpawning()
    {
        CancelInvoke("SpawnSierras");
    }

    /// <summary>
    /// Método llamado al inicio del ciclo de vida del objeto.
    /// Configura la gravedad inicial de las sierras y comienza la generación.
    /// </summary>
    void Start()
    {
        sierraSpawneable.GetComponent<Rigidbody2D>().gravityScale = 1f;
        StartSpawning();
    }

    /// <summary>
    /// Método llamado una vez por frame.
    /// Puede usarse para lógica adicional si es necesario.
    /// </summary>
    void Update()
    {
        // Lógica recurrente si es necesaria
    }
}
