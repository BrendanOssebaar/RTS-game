using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Queue<Command> _commands = new Queue<Command>();

    public void EnqueueCommand(Command command)
    {
        _commands.Enqueue(command);
    }
    public void ExecuteCommands()
    {
        if (_commands.Count >0)
        {
            Command command = _commands.Peek();
            if (command.IsCompleted())
            {
                _commands.Dequeue();
            }
            else
            {
                command.Execute();    
            }
        }
    }

    
}
