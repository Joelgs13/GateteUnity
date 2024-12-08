using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador del objeto Bonus en el juego. Maneja las interacciones del bonus con el jugador
/// y el entorno, así como su destrucción en determinados casos.
/// </summary>
public class BonusController : MonoBehaviour
{
    /// <summary>
    /// Método llamado al inicio del ciclo de vida del objeto.
    /// Puede ser utilizado para inicializar configuraciones específicas del bonus.
    /// </summary>
    void Start()
    {
        // Inicialización lógica si es necesaria
    }

    /// <summary>
    /// Método llamado una vez por frame. Puede utilizarse para lógica recurrente.
    /// </summary>
    void Update()
    {
        // Lógica recurrente si es necesaria
    }

    /// <summary>
    /// Detecta colisiones con otros objetos. Maneja la lógica cuando el bonus interactúa
    /// con el jugador o con el suelo.
    /// </summary>
    /// <param name="collision">El objeto con el que colisionó el bonus.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si colisiona con el jugador
        if (collision.gameObject.tag == "Player")
        {
            // Aumenta la puntuación del jugador aplicando el bonus
            GameManager.Instance.BonusPuntuacion();

            // Destruye el objeto bonus tras aplicar el efecto
            Destroy(gameObject);
        }
        // Si colisiona con el suelo
        else if (collision.gameObject.tag == "suelo")
        {
            // Destruye el objeto bonus
            Destroy(gameObject);
        }
    }
}
