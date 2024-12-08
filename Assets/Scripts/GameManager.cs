using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Clase principal para gestionar la lógica del juego, incluyendo el manejo del estado de Game Over,
/// la puntuación y la interacción con los generadores de elementos.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Referencia al canvas que muestra el menú de Game Over.
    /// </summary>
    public GameObject gameOverCanvas; 

    /// <summary>
    /// Instancia única de la clase GameManager (patrón Singleton).
    /// </summary>
    public static GameManager Instance;

    /// <summary>
    /// Indica si el juego ha terminado.
    /// </summary>
    bool gameOver = false;

    /// <summary>
    /// Puntuación actual del jugador.
    /// </summary>
    private int puntuacion = 0;

    /// <summary>
    /// Referencia al texto de la puntuación en pantalla (UI).
    /// </summary>
    public TMP_Text marcador;

    /// <summary>
    /// Método llamado al inicializar el objeto. Asigna la instancia única del GameManager.
    /// </summary>
    public void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Lógica para finalizar el juego. Detiene los generadores de elementos,
    /// muestra el menú de Game Over y registra un mensaje en la consola.
    /// </summary>
    public void GameOver()
    {
        gameOver = true;

        // Detener los generadores
        GameObject.Find("GeneradorSierras").GetComponent<GeneradorSierrasController>().StopSpawning();
        GameObject.Find("GeneradorSupervelocidad").GetComponent<GeneradorSupervelocidadController>().StopSpawning();
        GameObject.Find("GeneradorBonus").GetComponent<GeneradorBonusController>().StopSpawning();

        Debug.Log("HAS MUERTO. PAQUETE.");
        
        // Mostrar el menú de Game Over
        gameOverCanvas.SetActive(true);
    }

    /// <summary>
    /// Incrementa la puntuación en 1 si el juego no ha terminado. Actualiza el texto del marcador en pantalla.
    /// </summary>
    public void IncrementaPuntuacion()
    {
        if (!gameOver)
        {
            puntuacion++;
            print("TU PUNTUACION: " + puntuacion + "\n");
            marcador.text = puntuacion.ToString();
        }
    }

    /// <summary>
    /// Incrementa la puntuación en 5 (bonus) si el juego no ha terminado. Actualiza el texto del marcador en pantalla.
    /// </summary>
    public void BonusPuntuacion()
    {
        if (!gameOver)
        {
            puntuacion += 5;
            print("BONUS APLICADO: " + puntuacion + "\n");
            marcador.text = puntuacion.ToString();
        }
    }

    /// <summary>
    /// Método llamado al inicio del juego.
    /// </summary>
    void Start()
    {
        // Inicialización lógica si es necesaria
    }

    /// <summary>
    /// Método llamado una vez por frame. Puede usarse para lógica recurrente durante el juego.
    /// </summary>
    void Update()
    {
        // Lógica recurrente si es necesaria
    }
}
