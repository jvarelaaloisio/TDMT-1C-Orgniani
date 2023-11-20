using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private string tagToSearch = "Player";
    [SerializeField] private string nextLevel = "FirstLevel";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == tagToSearch)
            //TODO: TP2 - Fix - Hardcoded value/s --> DONE
            SceneManager.LoadScene(nextLevel);
    }
}
