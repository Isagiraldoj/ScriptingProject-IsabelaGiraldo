using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Variables públicas para ajustar en Unity
    public float moveSpeed = 5f;  // Velocidad de movimiento del jugador
    public float jumpForce = 10f;  // Fuerza de salto
    public LayerMask groundLayer;  // Capa de suelo para detectar si el jugador está tocando el suelo

    private Rigidbody2D rb;  // Componente Rigidbody2D del jugador
    private bool isGrounded;  // Comprobación de si el jugador está tocando el suelo
    private bool isGravityInverted = false;  // Bandera para invertir la gravedad

    private float moveInput; // Usamos un float para el movimiento en el eje X

    void Start()
    {
        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Llamar a los métodos de movimiento, salto y cambio de gravedad
        HandleMovement();
        HandleJump();
        HandleGravityToggle();
    }

    // Método para controlar el movimiento del jugador con el nuevo sistema de entrada
    void HandleMovement()
    {
        // Obtener el input de las teclas de movimiento usando el nuevo Input System
        if (Keyboard.current.aKey.isPressed)
        {
            moveInput = -1f;  // Movimiento hacia la izquierda
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            moveInput = 1f;  // Movimiento hacia la derecha
        }
        else
        {
            moveInput = 0f;  // Sin movimiento
        }

        // Mover al jugador (usando el movimiento en el eje X)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Mantener la velocidad en Y (sin cambiarla)
    }

    // Método para manejar el salto
    void HandleJump()
    {
        // Verificar si el jugador está tocando el suelo
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

        // Si está tocando el suelo y presiona la barra espaciadora, saltará
        if (isGrounded && Keyboard.current.spaceKey.isPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);  // Mantener la velocidad en X, cambiar solo la Y para el salto
        }
    }

    // Método para invertir la gravedad
    void HandleGravityToggle()
    {
        // Si se presiona la tecla "G", se invierte la gravedad
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            isGravityInverted = !isGravityInverted;
            // Cambiar la dirección de la gravedad
            Physics2D.gravity = isGravityInverted ? new Vector2(0, -9.8f) : new Vector2(0, 9.8f);

            // Alternar la dirección del sprite (si lo deseas)
            transform.Rotate(0f, 0f, 180f);
        }
    }
}
