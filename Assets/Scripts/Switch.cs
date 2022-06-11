using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Switch : MonoBehaviour, IInteractable
{
    [Header("Information about object")] [ReadOnly] [SerializeField]
    private SwitchState _currentState; 
    [Header("Materials")]
    [SerializeField] private Material _inactiveMaterial;
    [SerializeField] private Material _damagedMaterial;
    [SerializeField] private Material _brokenMaterial;
    [SerializeField] private Material _repairedMaterial;
    [SerializeField] private Material _destroyedMaterial;

    public SwitchState CurrentSwitchState { get => _currentState; }

    private void Start()
    {
        //TODO: начальное значение опредлеяет геймменеджер
        //ChangeState(SwitchState.Broken);
    }
    public void ChangeState(SwitchState newState)
    {
        switch (newState)
        {
            case SwitchState.Inactive:
                SetInactiveState();
                break;
            case SwitchState.Damaged:
                SerDamagedState();
                break;
            case SwitchState.Broken:
                SetBrokenState();
                break;
            case SwitchState.Repaired:
                SetRepairedState();
                break;
            case SwitchState.Destroyed:
                SetDestroyedState();
                break;
        }
    }
    private void Repair()
    {
        //TODO: действия для починки
        ChangeState(SwitchState.Repaired);
    }
    private void Destroy()
    {
        //TODO: действия для уничтожения 
        ChangeState(SwitchState.Destroyed);
    }
    
    public void Interact()
    {
        switch (CurrentSwitchState)
        {
            case SwitchState.Broken:
                Repair();
                break;
            default:
                return;
        }
    }
    
}
