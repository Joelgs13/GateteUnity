using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador para el comportamiento de las sierras.
/// Gestiona la rotación, colisiones y efectos asociados al jugador y el suelo.
/// </summary>
public class SawController : MonoBehaviour
{
    /// <summary>
    /// Velocidad de rotación de la sierra en grados por frame.
    /// Se puede configurar desde el Inspector.
    /// </summary>
    [SerializeField] float rotationSpeed = -11.0f;

    /// <summary>
    /// Método llamado al inicio del ciclo de vida del objeto.
    /// Se puede usar para inicializar lógica específica.
    /// </summary>
    void Start()
    { }

    /// <summary>
    /// Método llamado una vez por frame.
    /// Actualmente no contiene lógica, pero está preparado para futuras expansiones.
    /// </summary>
    void Update()
    { }

    /// <summary>
    /// Método llamado en cada frame fijo para manejar la lógica física.
    /// Aplica una rotación constante a la sierra.
    /// </summary>
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    /// <summary>
    /// Método llamado cuando el objeto colisiona con otro objeto que tiene un collider 2D.
    /// Gestiona el efecto de las colisiones con el jugador y el suelo.
    /// </summary>
    /// <param name="collision">El objeto con el que se detectó la colisión.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Si colisiona con el jugador, destruye al jugador y termina el juego
            Destroy(collision.gameObject);
            GameManager.Instance.GameOver();
        }
        else if (collision.gameObject.tag == "suelo")
        {
            // Si colisiona con el suelo, incrementa la puntuación
            GameManager.Instance.IncrementaPuntuacion();

            // Destruye la sierra después de incrementar la puntuación
            Destroy(gameObject);
        }
    }
}
