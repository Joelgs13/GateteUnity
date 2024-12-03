using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
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
             GameManager.Instance.BonusPuntuacion();


            // Destruye la foca después de aumentar la puntuación
            Destroy(gameObject);
            
        }
        else if (collision.gameObject.tag == "suelo")
        {
            // Destruye la foca
            Destroy(gameObject);
        }
    }
}
