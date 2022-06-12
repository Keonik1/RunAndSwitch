using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed = 40;

    private float _horizontalInput;
    private float _verticalInput;

    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        Move();
    }

    private void Move()
    {
        Vector3 movementVector = new Vector3(_horizontalInput, 0, _verticalInput).normalized;
        if (movementVector == Vector3.zero)
            return;

        SetDirection(movementVector);
        float axisInput = Mathf.Abs(_horizontalInput) + Mathf.Abs(_verticalInput);
        transform.Translate(Vector3.forward * _defaultSpeed * Time.deltaTime * Mathf.Clamp01(axisInput));
    }
    
    private void SetDirection(Vector3 movementVector)
    {
        Vector3 direction = Vector3.RotateTowards(transform.position, movementVector, 45, 0);
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
