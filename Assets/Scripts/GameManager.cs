using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas; 
    public static GameManager Instance;
    bool gameOver = false;
    private int puntuacion=0;
    public TMP_Text marcador;
    public void Awake(){
        Instance = this;
    }
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

    public void IncrementaPuntuacion(){
        if(!gameOver){
            puntuacion++;
            print("TU PUNTUACION: " + puntuacion+"\n");
            marcador.text=puntuacion.ToString();
        }
    }

    public void BonusPuntuacion(){
        if(!gameOver){
            puntuacion+=5;
            print("BONUS APLICADO: " + puntuacion+"\n");
            marcador.text=puntuacion.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
