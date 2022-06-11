using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private bool _canInteract = false;
    [SerializeField] private GameObject _interactableObject;
    private float _distancePlayerAndIntObj;

    private void Update()
    {
        
        
    }

    private void InteractWithObject(Collider obj)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pressed Space");
            if (obj.GetComponent<Switch>())
            {
                Debug.Log("Player says: 'Other have GetComponent<Switch> ");
                obj.GetComponent<Switch>().Interact();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Debug.Log($"Player collide with {other.name}");
        // _canInteract = true;
        // if (other.GetComponent<Switch>())
        //     _interactableObject = other.gameObject;
        InteractWithObject(other);
        
        
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     ResetInteract();
    //     
    // }
    private void ResetInteract()
    {
        _canInteract = false;
        _interactableObject = null;
    }
}
