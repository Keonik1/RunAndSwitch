using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _switches;
    [SerializeField] private GameObject _switchPrefab;
    [SerializeField] private int _countOfActiveSwitches = 3;

    private Vector3[] _startRowsPosition =
    {
        new Vector3(-5.25f, 0, 7.3f),   //top row
        new Vector3(-5.25f, 0, -7.3f),  //bottom row
        new Vector3(-6.75f, 0, 5.8f),   //left row
        new Vector3(6.75f, 0, 5.8f),    //right row
    };

    private List<Switch> _activeSwitches = new List<Switch>();

    private void Start()
    {
        SpawnSwitchs(_startRowsPosition, 1.5f);

        int childCount = _switches.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = _switches.transform.GetChild(i);
            child.GetComponent<Switch>().ChangeState(Switch.SwitchState.Inactive);
        }

        for (int i = 0; i < _countOfActiveSwitches; i++)
        {
            Switch randomSwitch;

            randomSwitch = GetRandomSwitch(childCount);
            if (randomSwitch.CurrentSwitchState != Switch.SwitchState.Inactive)
            {
                i--;
                continue;
            }
            SetActiveStateForSwitch(randomSwitch);
            AddToActiveSwitchesList(randomSwitch);
        }
    }

    private void SpawnSwitchs(Vector3[] startRowsPosition, float step)
    {
        for (int i = 0; i < _startRowsPosition.Length; i++)
        {
            int countOfSwitchInRow;
            if (i <= 1)
                countOfSwitchInRow = 8;
            else
                countOfSwitchInRow = 9;
            for (int j = 0; j < countOfSwitchInRow; j++)
            {
                float xPos = _startRowsPosition[i].x;
                float yPos = _startRowsPosition[i].y;
                float zPos = _startRowsPosition[i].z;
                Vector3 spawnPosition;
                Quaternion rotation = Quaternion.identity;

                if (i <= 1)
                {
                    spawnPosition = new Vector3(xPos + (step * j), yPos, zPos);
                    rotation = Quaternion.Euler(0, 90, 0);
                }
                else
                    spawnPosition = new Vector3(xPos, yPos, zPos - (step * j));

                Instantiate(_switchPrefab, spawnPosition, rotation, _switches.transform);
            }
        }
    }

    private Switch GetRandomSwitch(int childCount)
    {
        int randomSwitchIndex = Random.Range(0, childCount);
        Switch randomSwitch = _switches.transform.GetChild(randomSwitchIndex).GetComponent<Switch>();
        return randomSwitch;
    }

    private void SetActiveStateForSwitch(Switch @switch)
    {
        Switch.SwitchState randomState = (Switch.SwitchState) Random.Range(1, 3);
        @switch.ChangeState(randomState);
    }
    
    private void AddToActiveSwitchesList(Switch randomSwitch)
    {
        _activeSwitches.Add(randomSwitch);
    }
}
