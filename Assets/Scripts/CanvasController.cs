using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Image[] hearts;  // Array de imágenes de los corazones

    // Método para actualizar las vidas
    public void UpdateLives(int currentLives)
    {
        // Recorremos el array de corazones
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                // Activamos el corazón (cuando el jugador tiene vida)
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                // Desactivamos el corazón (cuando el jugador pierde vida)
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
}
