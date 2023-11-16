using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private HealthController characterHP;
    [SerializeField] private GameOverScreen screen;
    [SerializeField] private AudioSource gameMusic;

    private void Update()
    {
        if (characterHP.HP <= 0)
        {
            screen.Setup();
            gameMusic.Stop();
        }
    }
}
