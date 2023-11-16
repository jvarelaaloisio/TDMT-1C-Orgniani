using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private string tagToSearch = "Player";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == tagToSearch)
            //TODO: TP2 - Fix - Hardcoded value/s --> ASK
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
