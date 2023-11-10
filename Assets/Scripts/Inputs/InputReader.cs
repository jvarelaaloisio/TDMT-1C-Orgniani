using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterShooting attack;

    [SerializeField] private HealthController playerHP;

    [SerializeField] private OpenDoor enemies;

    public void SetMovementValue(InputAction.CallbackContext inputContext)
    {
        if (!characterMovement)
            return;

        //TODO: TP2 - Fix - Enabling movement based on HP should be handled by the character, not the input class
        if (playerHP.HP > 0)
        {
            Vector2 inputValue = inputContext.ReadValue<Vector2>();
            characterMovement.SetDirection(inputValue);
        }
    }

    public void Shoot(InputAction.CallbackContext inputContext)
    {
        if (inputContext.started && playerHP.HP > 0)
        {
            if (attack == null)
            {
                Debug.LogError($"{name}: CharacterShooting is null!");
                return;
            }

            attack.Shoot(characterMovement.lastDirection);
        }
    }

    public void DamageAllEnemiesCheat(InputAction.CallbackContext inputContext)
    {
        if(enemies == null)
        {
            Debug.LogError($"{name}: EnemiesManager is null!");
            return;
        }

        enemies.DamageAllEnemies();
    }
}