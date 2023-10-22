using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public Vector2 direction;
    public Vector2 lastDirection;

    public Vector2 currentPosition;

    [SerializeField] private CharacterShooting attack;

    private void Start()
    {
        lastDirection.Set(-1, 0);
    }
    private void Update()
    {
        if(attack == null)
            Debug.LogError($"{name}: CharacterShooting in CharacterMovement is null.");

        if (attack.canShoot)
        {
            transform.position = transform.position + speed * Time.deltaTime * new Vector3(direction.x, direction.y);
            currentPosition = transform.position;
        }

    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
        if(direction != Vector2.zero)
        {
            lastDirection = direction;
        }
    }
}