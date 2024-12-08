using System.Collections;
using UnityEngine;

/// <summary>
/// Controlador para el jugador, gestionando el movimiento y los efectos temporales como el aumento de velocidad.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Componente Rigidbody2D del jugador, usado para aplicar movimiento.
    /// </summary>
    Rigidbody2D rb;

    /// <summary>
    /// Componente SpriteRenderer del jugador, usado para controlar la dirección del sprite.
    /// </summary>
    SpriteRenderer sr;

    /// <summary>
    /// Componente Animator del jugador, usado para manejar animaciones.
    /// </summary>
    Animator animator;

    /// <summary>
    /// Velocidad base del jugador.
    /// Se puede ajustar desde el Inspector.
    /// </summary>
    [SerializeField] float velocidad;

    /// <summary>
    /// Se ejecuta al inicializar el objeto.
    /// Obtiene referencias a los componentes necesarios.
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // Obtiene el componente Animator
    }

    /// <summary>
    /// Se ejecuta en cada frame fijo.
    /// Maneja el movimiento del jugador basado en la posición del mouse.
    /// </summary>
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            // Detecta si el clic ocurre en la mitad izquierda o derecha de la pantalla
            if (Input.mousePosition.x < Screen.width / 2)
            {
                // Mover hacia la izquierda
                rb.velocity = Vector2.left * velocidad;
                sr.flipX = true;
                // animator.SetBool("isWalking", true); // Cambia a la animación de caminar
            }
            else if (Input.mousePosition.x > Screen.width / 2)
            {
                // Mover hacia la derecha
                rb.velocity = Vector2.right * velocidad;
                sr.flipX = false;
                // animator.SetBool("isWalking", true); // Cambia a la animación de caminar
            }
        }
        else
        {
            // Si no hay clic, el jugador no se mueve
            rb.velocity = Vector2.zero;
            // animator.SetBool("isWalking", false); // Cambia a la animación de idle
        }
    }

    /// <summary>
    /// Aplica un aumento temporal de velocidad al jugador.
    /// </summary>
    /// <param name="multiplier">Factor por el cual se multiplica la velocidad base.</param>
    /// <param name="duration">Duración del efecto en segundos.</param>
    public void MultiplySpeed(float multiplier, float duration)
    {
        // Inicia la corrutina para aplicar el aumento de velocidad
        StartCoroutine(SpeedBoost(multiplier, duration));
    }

    /// <summary>
    /// Corrutina que gestiona el efecto temporal de aumento de velocidad.
    /// </summary>
    /// <param name="multiplier">Factor por el cual se multiplica la velocidad base.</param>
    /// <param name="duration">Duración del efecto en segundos.</param>
    /// <returns>Devuelve un enumerador para manejar la espera de tiempo.</returns>
    private IEnumerator SpeedBoost(float multiplier, float duration)
    {
        // Incrementa la velocidad base
        velocidad *= multiplier;

        // Espera la duración especificada
        yield return new WaitForSeconds(duration);

        // Restaura la velocidad original
        velocidad /= multiplier;
    }

    /// <summary>
    /// Método llamado al inicio del ciclo de vida del objeto.
    /// Puede usarse para inicializar lógica adicional si es necesario.
    /// </summary>
    void Start()
    { }

    /// <summary>
    /// Método llamado en cada frame.
    /// Puede usarse para manejar lógica adicional basada en la entrada o el estado.
    /// </summary>
    void Update()
    { }
}
