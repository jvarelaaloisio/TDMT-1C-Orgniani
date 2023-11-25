using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 0;
    [SerializeField] private int nextLevelBuildIndex = 1;
    [SerializeField] private int firstLevelBuildIndex = 2;
    [SerializeField] private int mainMenuBuildIndex = 0;

    public void GoToNextLevel()
    {
        LoadScene(nextLevelBuildIndex);
    }

    public void RestartGame()
    {
        LoadScene(firstLevelBuildIndex);
    }

    public void RestartLevel()
    {
        LoadScene(currentLevel);
    }

    public void BackToMenu()
    {
        LoadScene(mainMenuBuildIndex);
    }

    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
