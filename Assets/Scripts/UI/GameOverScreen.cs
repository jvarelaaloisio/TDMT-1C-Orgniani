using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc) --> DONE
    [SerializeField] private PauseScreen pauseScreen;

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(gameObject.scene.name);
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseButton()
    {
        pauseScreen.PauseGame();
    }
}
