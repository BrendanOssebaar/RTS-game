using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    public Queue<ICommand> _commands = new Queue<ICommand>();

    public void EnqueueCommand(ICommand command)
    {
        _commands.Enqueue(command);
    }
    public void ExecuteCommands()
    {
        while (_commands.Count >0)
        {
            ICommand command = _commands.Dequeue();
            command.Execute();
        }
    }
}
