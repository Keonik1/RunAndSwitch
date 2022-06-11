using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed = 40;

    private float _horizontalInput;
    private float _verticalInput;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float speed = _defaultSpeed;
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movementVector = new Vector3(_horizontalInput, 0, _verticalInput).normalized;
        
        if (movementVector == Vector3.zero)
            return;
        
        Quaternion rotation = Quaternion.LookRotation(movementVector);
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, 360 * Time.deltaTime);
        

        // if (_horizontalInput != 0 && _verticalInput != 0)
        // {
        //     speed = _defaultSpeed / Mathf.Sqrt(2); 
        //     //TODO: Заменить Math.Sqrt(2) на косинус угла между вектором движения и к горизонтальной линии
        // }

        transform.Translate(movementVector * Time.deltaTime * speed);
        _rigidbody.MoveRotation(rotation);
    }
}
