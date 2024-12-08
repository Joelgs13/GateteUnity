using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador para gestionar las acciones del menú principal del juego.
/// Permite iniciar el juego y cerrar la aplicación.
/// </summary>
public class MainMenuController : MonoBehaviour
{
    /// <summary>
    /// Carga la escena principal del juego.
    /// Debe llamarse desde el botón "Jugar" en el menú principal.
    /// </summary>
    public void PlayGame()
    {
        // Carga la escena con el nombre "Gatete"
        SceneManager.LoadScene("Gatete");
    }

    /// <summary>
    /// Cierra la aplicación. 
    /// En el editor de Unity, solo muestra un mensaje en la consola.
    /// Debe llamarse desde el botón "Salir" en el menú principal.
    /// </summary>
    public void ExitGame()
    {
        // Muestra un mensaje de depuración en el editor
        Debug.Log("Saliendo del juego...");

        // Cierra la aplicación
        Application.Quit();
    }
}
