
# **Proyecto UpsideDown Isabela Giraldo Jimenez**

## **Descripción del Proyecto**

El proyecto consiste en el desarrollo de un juego plataformero donde el jugador controla a un personaje que debe superar un nivel con obstáculos y desafíos. El juego contará con una mecánica que será la capacidad de invertir la gravedad, o sea, la persona puede decidir si va a caminar en el techo o en el suelo.

El objetivo del juego es llegar al final del nivel, superando obstáculos y recolectando objetos opcionales que aumenten la puntuación del jugador. El juego tendrá un estilo visual como túnel.


## **Estructura del Proyecto**
* **`PlayerController.cs`**: Contiene la lógica principal para manejar las mecanicas del jugador.
* **`GameManager.cs`**: Contiene la lógica principal para manejar las vidas del jugador, el reinicio de la escena y el control de **Game Over**.
* **`CanvasController.cs`**: Actualiza la interfaz de usuario mostrando las vidas actuales del jugador.
* **`GameManagerTests.cs`**: Contiene las pruebas unitarias para verificar que el sistema de vidas funcione correctamente.
* **`PlayModeTests/`**: Carpeta que contiene las pruebas en **PlayMode**, que se ejecutan mientras el juego está corriendo.

## **Cómo jugar**

1. **Controles del jugador**:

   * **`A`**: Moverse hacia la izquierda.
   * **`D`**: Moverse hacia la derecha.
   * **`Barra espaciadora`**: Saltar.
   * **`G`**: Invertir la gravedad (cambia la dirección en la que el jugador camina, permitiendo caminar en el techo o en el suelo).

2. **Objetivo del juego**:

   * El objetivo es **esquivar los lagos** y llegar al final del nivel. El jugador **pierde una vida** al entrar en contacto con los lagos.
   * Cuando las **vidas lleguen a 0**, el juego se **reinicia automáticamente**.

3. **Interfaz de Usuario (UI)**:

   * En la parte superior de la pantalla se muestran los **corazones**, que representan las **vidas** del jugador. Cada vez que el jugador pierde una vida, un corazón desaparecerá.

---

## **Cómo ejecutar el juego**

1. Abre el proyecto en Unity.
2. Haz clic en **Play** en Unity para ejecutar la escena principal.
3. Durante el juego, puedes perder vidas al interactuar con enemigos o caer en el lago (o cualquier evento que definas para perder vidas).
4. Cuando las vidas lleguen a 0, el juego se reiniciará automáticamente.

## **Cómo ejecutar las pruebas**

1. Abre el **Test Runner** en Unity: **Window > General > Test Runner**.
2. **Selecciona PlayMode** en el Test Runner.
3. Haz clic en **Run All** para ejecutar todas las pruebas.
4. Las pruebas verifican lo siguiente:

   * **`LoseLife_DecreasesLives`**: Verifica que las vidas disminuyan cuando el jugador pierde una vida.
   * **`LoseLife_GameOver_WhenLivesReachZero`**: Verifica que el juego se reinicie correctamente cuando las vidas lleguen a 0.


## **Cómo funcionan las pruebas**

El sistema de pruebas está basado en el patrón **PlayMode**. Las pruebas se ejecutan mientras el juego está en ejecución, permitiendo verificar el comportamiento en tiempo real:

* **\[SetUp]**: Inicializa el entorno del juego (crea las instancias de `GameManager` y `CanvasController`).
* **\[UnityTest]**: Se utiliza para pruebas en **PlayMode**, permitiendo verificar el comportamiento dinámico del juego (como la disminución de vidas y el reinicio de la escena).
* **\[TearDown]**: Se ejecuta después de cada prueba para limpiar y destruir los objetos creados en **SetUp**.

### **Pruebas Importantes**:

* **`LoseLife_DecreasesLives`**: Verifica que las vidas se disminuyan correctamente cuando el jugador pierde una vida.
* **`LoseLife_GameOver_WhenLivesReachZero`**: Verifica que el juego reinicie la escena cuando las vidas lleguen a 0.


## **Créditos y Fuentes de Recursos**

En este proyecto, se han utilizado diversos recursos de arte gratuitos y tutoriales para mejorar la calidad visual del juego. A continuación se listan los lugares y los materiales que se utilizaron:

### **Recursos de Arte Utilizados**:

1. **[Swamp 2D Tileset - Pixel Art](https://free-game-assets.itch.io/free-swamp-2d-tileset-pixel-art/download/eyJpZCI6NTkzMTExLCJleHBpcmVzIjoxNzQ3NTk2Njc1fQ%3D%3D.kgRND%2B2aYdHDk685UfbBhoT20%2Bc%3D)**

   * **Fuente**: [Itch.io](https://free-game-assets.itch.io)
   * **Descripción**: Tileset 2D estilo pixel art utilizado para representar el entorno del juego, específicamente para crear la zona del pantano.

2. **[Funny Pixel Boy](https://opengameart.org/content/funny-pixel-boy)**

   * **Fuente**: [OpenGameArt](https://opengameart.org)
   * **Descripción**: Personaje principal para el juego, proporcionado como sprite en estilo pixel art.

3. **[Pixel Heart Animation](https://nicolemariet.itch.io/pixel-heart-animation-32x32-16x16-freebie?download)**

   * **Fuente**: [Itch.io](https://nicolemariet.itch.io)
   * **Descripción**: Animaciones de corazones en pixel art utilizadas para representar las vidas del jugador en la interfaz de usuario.

### **Tutoriales Utilizados**:

1. **[RocketJam YouTube Channel](https://www.youtube.com/@RocketJam)**

   * **Fuente**: [YouTube - RocketJam](https://www.youtube.com/@RocketJam)
   * **Descripción**: Canal de YouTube con tutoriales sobre cómo crear juegos en Unity y cómo mejorar el arte pixelado. Se siguieron varios tutoriales para mejorar las animaciones y los efectos visuales en el juego.
