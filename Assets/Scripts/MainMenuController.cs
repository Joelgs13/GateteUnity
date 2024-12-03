using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        // Carga la escena principal del juego
        SceneManager.LoadScene("Gatete");
    }

    public void ExitGame()
    {
        // Cierra la aplicación
        Debug.Log("Saliendo del juego..."); // Solo visible en el editor
        Application.Quit();
    }
}