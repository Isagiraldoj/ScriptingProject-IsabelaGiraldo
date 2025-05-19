using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Instancia única del GameManager

    public int lives = 3;
    public int score = 0;
    public CanvasController canvasController;

    void Awake()
    {
        // Aseguramos que haya solo una instancia del GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Mantiene esta instancia entre escenas
        }
        else
        {
            Destroy(gameObject);  // Si ya existe, destruye el objeto duplicado
        }
    }

    void Start()
    {
        // Inicializa las vidas en el Canvas
        canvasController.UpdateLives(lives);
    }

    public void LoseLife()
    {
        lives--;
        canvasController.UpdateLives(lives);  // Actualizar la UI

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Aquí puedes manejar el fin del juego, como reiniciar la escena
        Debug.Log("Game Over");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
