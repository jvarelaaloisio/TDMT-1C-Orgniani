using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterShooting attack;

    [SerializeField] private HealthPoints playerHP;

    public void SetMovementValue(InputAction.CallbackContext inputContext)
    {
        if (!characterMovement)
            return;

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
}