using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador del menú de Game Over. Maneja la lógica para mostrar el menú,
/// reiniciar el juego o volver al menú principal.
/// </summary>
public class GameOverMenuController : MonoBehaviour
{
    /// <summary>
    /// Referencia al canvas del menú de Game Over. Debe asignarse desde el Inspector.
    /// </summary>
    public GameObject gameOverCanvas;

    /// <summary>
    /// Activa y muestra el menú de Game Over.
    /// </summary>
    public void ShowGameOverMenu()
    {
        // Activa el menú de Game Over
        gameOverCanvas.SetActive(true);
    }

    /// <summary>
    /// Reinicia la partida cargando la escena actual desde el principio.
    /// </summary>
    public void RetryGame()
    {
        // Recarga la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Regresa al menú principal cargando la escena correspondiente.
    /// </summary>
    public void GoToMenu()
    {
        // Carga la escena del menú principal
        SceneManager.LoadScene("MenuDelJuego");
    }
}
