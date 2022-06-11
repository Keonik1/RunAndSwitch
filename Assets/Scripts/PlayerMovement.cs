using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed = 40;
    [SerializeField] private MovementMethod _movementMethod;

    private float _horizontalInput;
    private float _verticalInput;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float speed = _defaultSpeed;
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        Move(_movementMethod, speed);
    }
    private void Move(MovementMethod movementMethod, float speed)
    {
        switch (movementMethod)
        {
            case MovementMethod.ThroughANewVector:
                Vector3 movementVector = new Vector3(_horizontalInput, 0, _verticalInput).normalized;
                transform.Translate(movementVector * speed * Time.deltaTime);
                break;
            case MovementMethod.ThroughSpeedChange:
                if (_verticalInput != 0 && _horizontalInput != 0)
                    speed = _defaultSpeed / Mathf.Sqrt(2);
    
                transform.Translate(Vector3.forward * speed * Time.deltaTime * _verticalInput);
                transform.Translate(Vector3.right * speed * Time.deltaTime * _horizontalInput);
                break;
        }
    }

    private enum MovementMethod
    {
        ThroughANewVector, ThroughSpeedChange
    }
}
