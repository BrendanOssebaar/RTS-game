using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class UnitManager : MonoBehaviour
{
    public GameObject target;
    private readonly Unit _unit = new Unit();
    // void Main()
    // {
    //     _unit.EnqueueCommand(new MoveCommand());
    //     _unit.EnqueueCommand(new AttackCommand());
    //     _unit.EnqueueCommand(new RetreatCommand());
    //     _unit.ExecuteCommands();
    // }

    void Update()
    {
        if (_unit._commands.Count > 0)
        {
            _unit.ExecuteCommands();
        }

        // if (Input.GetMouseButtonDown(1))
        // {
        //     _unit.EnqueueCommand(new AttackCommand());
        // }

        // if (Input.GetMouseButtonDown(2))
        // {
        //     _unit.EnqueueCommand(new RetreatCommand());
        // }
        
    }
}
