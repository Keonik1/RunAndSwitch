using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Switch
{
    public enum SwitchState
    {
        Inactive,
        Damaged,
        Broken,
        Repaired,
        Destroyed
    }
    
    private void SetInactiveState()
    {
        _currentState = SwitchState.Inactive;
        gameObject.GetComponent<MeshRenderer>().material = _inactiveMaterial;
    }
    private void SerDamagedState()
    {
        _currentState = SwitchState.Damaged;
        gameObject.GetComponent<MeshRenderer>().material = _damagedMaterial;
    }
    private void SetBrokenState()
    {
        _currentState = SwitchState.Broken;
        gameObject.GetComponent<MeshRenderer>().material = _brokenMaterial;
    }
    private void SetRepairedState()
    {
        _currentState = SwitchState.Repaired;
        gameObject.GetComponent<MeshRenderer>().material = _repairedMaterial;
    }
    private void SetDestroyedState()
    {
        _currentState = SwitchState.Destroyed;
        gameObject.GetComponent<MeshRenderer>().material = _destroyedMaterial;
    }
}
