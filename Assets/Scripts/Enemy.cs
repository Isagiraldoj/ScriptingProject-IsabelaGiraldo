using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;  // Daño que hace el enemigo

    void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobar si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            // Usar FindFirstObjectByType en lugar de FindObjectOfType
            GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
            gameManager.LoseLife();  // Llama al método para restar una vida
        }
    }
}
