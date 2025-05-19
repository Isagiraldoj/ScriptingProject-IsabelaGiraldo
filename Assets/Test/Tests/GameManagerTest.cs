using System.Collections;  // Asegúrate de tener este using para IEnumerator
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

[TestFixture]
public class GameManagerTests
{
    private GameManager gameManager;
    private CanvasController canvasController;

    [SetUp]
    public void SetUp()
    {
        // Crear un objeto vacío para el GameManager
        var gameObject = new GameObject();
        gameManager = gameObject.AddComponent<GameManager>();

        // Crear un objeto vacío para el CanvasController
        var canvasObject = new GameObject();
        canvasController = canvasObject.AddComponent<CanvasController>();

        // Asignar el CanvasController al GameManager
        gameManager.canvasController = canvasController;

        // Configurar la escena y las dependencias necesarias
        canvasController.UpdateLives(gameManager.lives);
    }

    // Test de que las vidas se reducen correctamente
    [Test]
    public void LoseLife_DecreasesLives()
    {
        // Precondición: El GameManager tiene 3 vidas
        Assert.AreEqual(3, gameManager.lives);

        // Act: Llamamos a LoseLife
        gameManager.LoseLife();

        // Postcondición: Las vidas deben disminuir a 2
        Assert.AreEqual(2, gameManager.lives);
    }

    // Test de GameOver cuando las vidas llegan a 0
    [UnityTest]
    public IEnumerator LoseLife_GameOver_WhenLivesReachZero()
    {
        // Establecer el número de vidas en 1
        gameManager.lives = 1;
        canvasController.UpdateLives(gameManager.lives);

        // Act: Llamamos a LoseLife y esperamos que se llegue a 0
        gameManager.LoseLife();

        // Esperar un frame para que los cambios se reflejen
        yield return null;

        // Verificar que las vidas sean 0
        Assert.AreEqual(0, gameManager.lives);

        // Verificar que la escena se haya reiniciado o que se llame a GameOver
        Assert.AreEqual(SceneManager.GetActiveScene().name, "YourSceneName"); // Asegúrate de que la escena se reinicie correctamente
    }

    [TearDown]
    public void TearDown()
    {
        // Limpiar después de cada prueba
        Object.Destroy(gameManager.gameObject);
        Object.Destroy(canvasController.gameObject);
    }
}
