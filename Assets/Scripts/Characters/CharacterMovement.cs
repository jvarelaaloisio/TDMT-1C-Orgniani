using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public Vector2 _direction;
    public Vector2 _lastDirection;

    public Vector2 currentPosition;

    [SerializeField] private CharacterShooting characterShooting;

    private void Start()
    {
        _lastDirection.Set(-1, 0);
    }
    private void Update()
    {
        if(characterShooting == null)
            Debug.LogError($"{name}: CharacterShooting in CharacterMovement is NULL");

        if (characterShooting.canShoot)
        {
            transform.position = transform.position + speed * Time.deltaTime * new Vector3(_direction.x, _direction.y);
            currentPosition = transform.position;
        }
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        if(direction != Vector2.zero)
        {
            _lastDirection = direction;
        }
    }
}