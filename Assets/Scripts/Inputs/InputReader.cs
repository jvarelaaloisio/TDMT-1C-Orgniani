using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Gun gun;

    [SerializeField] private HealthPoints playerHP;

    public void SetMovementValue(InputAction.CallbackContext inputContext)
    {
        if (!characterMovement)
            return;

        if (playerHP.HP > 0)
        {
            Vector2 inputValue = inputContext.ReadValue<Vector2>();
            characterMovement.SetDirection(inputValue);

            Debug.Log($"{gameObject.name}: Event risen. Value: {inputValue}");
        }
    }

    public void Shoot(InputAction.CallbackContext inputContext)
    {
        if (inputContext.started && playerHP.HP > 0)
        {
            //NULL CHECK
            if (gun == null)
            {
                Debug.LogError($"{name}: Gun is null! </3");
                return;
            }

            gun.Shoot(characterMovement.GetLastDirection());
        }
    }
}