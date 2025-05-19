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

        // Si la gravedad está invertida, cambiar la dirección del movimiento horizontal
        if (isGravityInverted)
        {
            moveInput = -moveInput;  // Invertir el movimiento horizontal
        }

        // Mover al jugador (usando el movimiento en el eje X)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Mantener la velocidad en Y (sin cambiarla)

        // Rotar el personaje según la dirección del movimiento
        if (moveInput != 0)
        {
            // Si el movimiento es a la izquierda, giramos el sprite para que mire hacia la izquierda, si es a la derecha, lo giramos a la derecha.
            transform.localScale = new Vector3(Mathf.Sign(moveInput), transform.localScale.y, 1f);
        }
    }

    // Método para manejar el salto
    void HandleJump()
    {
        // Verificar si el jugador está tocando el suelo usando Raycast y la capa Ground
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

        // Para depuración, dibujar la línea del Raycast en la escena
        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);

        // Si está tocando el suelo y presiona la barra espaciadora, saltará
        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);  // Mantener la velocidad en X, cambiar solo la Y para el salto

            // Rotar 180 grados para "colgarse de los pies"
            transform.Rotate(0f, 180f, 0f); // Rota en el eje Y
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

            // Ajustar la posición y escala del personaje dependiendo de la gravedad
            AdjustCharacterPositionAndRotation();
        }
    }

    // Método para ajustar la posición y la rotación del personaje dependiendo de la gravedad
    void AdjustCharacterPositionAndRotation()
    {
        // Si la gravedad está invertida, invertir la escala del personaje
        if (isGravityInverted)
        {
            transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), 1f);
            // Ajustar la posición en el eje Y para que el personaje esté "pegado" al techo
            rb.position = new Vector2(rb.position.x, rb.position.y + 0.5f);  // Ajuste de posición (según el tamaño del personaje)
        }
        else
        {
            // Restaurar la escala normal para el personaje
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), 1f);
            // Ajustar la posición en el eje Y para que el personaje esté "pegado" al suelo
            rb.position = new Vector2(rb.position.x, rb.position.y - 0.5f);  // Ajuste de posición (según el tamaño del personaje)
        }
    }
}
