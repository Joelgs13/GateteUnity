using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb; // Para obtener la velocidad del jugador

    private void Awake()
    {
        // Referencia al componente Animator
        animator = GetComponent<Animator>();
        // Referencia al Rigidbody2D para conocer el movimiento
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Comprobar si el jugador está en movimiento
        bool isWalking = rb.velocity.x != 0; // Si la velocidad en X no es 0, está caminando

        // Actualizar el parámetro "isWalking" del Animator
        animator.SetBool("isWalking", isWalking);
    }
}
