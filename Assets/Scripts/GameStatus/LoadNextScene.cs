using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private string tagToSearch = "Player";
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == tagToSearch)
            //TODO: TP2 - Fix - Hardcoded value/s --> DONE
            gameManager.GoToNextLevel();
    }
}
