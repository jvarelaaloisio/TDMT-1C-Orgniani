using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private HealthController characterHP;
    [SerializeField] private GameOverScreen screen;
    [SerializeField] private AudioSource gameMusic;

    private void OnEnable()
    {
        characterHP.onDead += GameOverScreenSetup;
    }

    private void OnDisable()
    {
        characterHP.onDead -= GameOverScreenSetup;
    }

    private void GameOverScreenSetup()
    {
        screen.Setup();
        gameMusic.Stop();
    }
}
