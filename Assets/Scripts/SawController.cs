using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{

    [SerializeField] float rotationSpeed = -11.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.tag == "Player")
    {
        // Toca al jugador, destruyelo
        Destroy(collision.gameObject);
        GameManager.Instance.GameOver();
        
    }
    else if (collision.gameObject.tag == "suelo")
    {
        // Evita incrementar la puntuación varias veces
        GameManager.Instance.IncrementaPuntuacion();


        // Destruye la sierra después de aumentar la puntuación
        Destroy(gameObject);
    }
}

}