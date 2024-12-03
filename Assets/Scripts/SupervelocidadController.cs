using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupervelocidadController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player")
        {
             PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Multiplica la velocidad actual por 1.5
                playerController.MultiplySpeed(1.5f, 15f);
            }

            // Destruye el objeto del power-up
            Destroy(gameObject);
            
        }
        else if (collision.gameObject.tag == "suelo")
        {
            // Destruye la bota
            Destroy(gameObject);
        }
    }
}
