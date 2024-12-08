using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador para el power-up de supervelocidad.
/// Gestiona las interacciones del objeto con el jugador y otros elementos del entorno.
/// </summary>
public class SupervelocidadController : MonoBehaviour
{
    /// <summary>
    /// Método llamado al inicio del ciclo de vida del objeto.
    /// Actualmente no contiene lógica, pero está preparado para futuras expansiones.
    /// </summary>
    void Start()
    { }

    /// <summary>
    /// Método llamado en cada frame.
    /// Actualmente no contiene lógica, pero está preparado para futuras expansiones.
    /// </summary>
    void Update()
    { }

    /// <summary>
    /// Método llamado cuando el objeto colisiona con otro objeto que tiene un collider 2D.
    /// Aplica el efecto de supervelocidad al jugador y destruye el power-up.
    /// </summary>
    /// <param name="collision">El objeto con el que se detectó la colisión.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Intenta obtener el controlador del jugador
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Aplica un multiplicador de velocidad de 1.5 durante 15 segundos
                playerController.MultiplySpeed(1.5f, 15f);
            }

            // Destruye el objeto del power-up
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "suelo")
        {
            // Si colisiona con el suelo, destruye el objeto
            Destroy(gameObject);
        }
    }
}
