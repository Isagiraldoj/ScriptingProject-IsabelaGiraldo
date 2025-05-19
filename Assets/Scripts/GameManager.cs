using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class GameManager : MonoBehaviour
{
    public int lives = 3;  // Vidas iniciales
    public int score = 0;   // Puntos iniciales
    public CanvasController canvasController;  // Referencia al CanvasController

    void Start()
    {
        // Inicializar las vidas en el Canvas
        canvasController.UpdateLives(lives);
    }

    // Método para restar vida al jugador
    public void LoseLife()
    {
        lives--;  // Restar una vida
        canvasController.UpdateLives(lives);  // Actualizar el Canvas con las nuevas vidas

        if (lives <= 0)
        {
            // Cuando las vidas llegan a 0, se reinicia la escena
            GameOver();
        }
    }

    // Método de Game Over
    void GameOver()
    {
        // Muestra el mensaje de Game Over
        Debug.Log("Game Over");

        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
