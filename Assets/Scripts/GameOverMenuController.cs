using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    public GameObject gameOverCanvas; // Arrastra aquí el GameOverCanvas desde el inspector

    public void ShowGameOverMenu()
    {
        // Activa el menú de Game Over
        gameOverCanvas.SetActive(true);
    }

    public void RetryGame()
    {
        // Recarga la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        // Carga la escena del menú principal
        SceneManager.LoadScene("MenuDelJuego");
    }
}
