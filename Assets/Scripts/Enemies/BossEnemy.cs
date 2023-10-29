using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private CharacterShooting attack;
    [SerializeField] private HealthPoints enemyHP;

    [SerializeField] private CharacterMovement targetPosition;
    [SerializeField] private HealthPoints targetHP;

    [SerializeField] private List<GameObject> frogs;

    [SerializeField] private float spawnDelay = 1f;

    private void Update()
    {
        if (enemyHP.HP > 0 && targetHP.HP > 0)
        {
            ShootAndSpawn();
        }
    }
    
    private void ShootAndSpawn()
    {
        if (attack == null)
        {
            Debug.LogError($"{name}: CharacterShooting is null!");
            return;
        }

        if (targetPosition == null)
            Debug.LogError($"{name}: Target is null!");

        else
        {
            Vector2 currentPosition = transform.position;

            Vector2 nextPosition = targetPosition.currentPosition;
            Vector2 nextPosition2 = targetPosition.currentPosition - new Vector2(3, 0);
            Vector2 nextPosition3 = targetPosition.currentPosition + new Vector2(3, 0);

            Vector2 directionToNextPos = nextPosition - currentPosition;
            Vector2 directionToNextPos2 = nextPosition2 - currentPosition;
            Vector2 directionToNextPos3 = nextPosition3 - currentPosition;

            attack.BossShoot(directionToNextPos, directionToNextPos2, directionToNextPos3);
            StartCoroutine(SpawnFrogs());
        }
    }

    private IEnumerator SpawnFrogs()
    {
        foreach (GameObject frog in frogs)
        {
            if (frog.GetComponent<Collider2D>().enabled == true)
                frog.SetActive(true);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
