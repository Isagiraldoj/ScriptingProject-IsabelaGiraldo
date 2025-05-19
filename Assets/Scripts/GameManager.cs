using UnityEngine;

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
            // Aquí puedes manejar el Game Over, por ejemplo, reiniciar el juego
            GameOver();
        }
    }

    // Método de Game Over
    void GameOver()
    {
        Debug.Log("Game Over");
        // Implementa la lógica de fin del juego (como mostrar un mensaje de Game Over)
    }
}
