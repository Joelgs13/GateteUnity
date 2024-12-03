using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator; // Referencia al Animator
    [SerializeField] float velocidad;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // Obtiene el componente Animator
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                rb.velocity = Vector2.left * velocidad;
                sr.flipX = true;
                //animator.SetBool("isWalking", true); // Cambia a la animación de caminar
            }
            else if (Input.mousePosition.x > Screen.width / 2)
            {
                rb.velocity = Vector2.right * velocidad;
                sr.flipX = false;
                //animator.SetBool("isWalking", true); // Cambia a la animación de caminar
            }
        }
        else
        {
            // Si no se detecta clic, el jugador no se mueve
            rb.velocity = Vector2.zero;
            //animator.SetBool("isWalking", false); // Cambia a la animación de idle
        }
    }

    public void MultiplySpeed(float multiplier, float duration)
    {
        // Inicia la corrutina del boost
        StartCoroutine(SpeedBoost(multiplier, duration));
    }

    private IEnumerator SpeedBoost(float multiplier, float duration)
    {
        // Incrementa la velocidad
        velocidad *= multiplier;

        // Espera la duración del boost
        yield return new WaitForSeconds(duration);

        // Reduce la velocidad en la misma proporción
        velocidad /= multiplier;
    }

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    { }
}
