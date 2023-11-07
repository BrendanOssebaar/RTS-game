using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private readonly Queue<Command> _commandQueue = new Queue<Command>();

    public void ExecuteCommand(Command command)
    {
        if (_commandQueue.Count > 0)
        {
            Command currentCommand = _commandQueue.Peek();
            if (!currentCommand.IsCompleted())
            {
                currentCommand.Cancel();
            }
        }
        _commandQueue.Enqueue(command);
        StartCoroutine(ExecuteCommands());
    }
    private IEnumerator ExecuteCommands()
    {
        while (_commandQueue.Count > 0)
        {
            Command command = _commandQueue.Peek();

            command.Execute(gameObject);

            while (!command.IsCompleted())
            {
                yield return null;
            }

            // Command completed, dequeue it
            _commandQueue.Dequeue();
        }
    }
    private void Update()
    {
        if (_commandQueue.Count >0)
        {
            Command currentCommand = _commandQueue.Peek();
            bool completed = currentCommand.Execute(gameObject);
            if (completed)
            {
                _commandQueue.Dequeue();
            }
        }
    }

    // public void EnqueueCommand(Command command)
    // {
    //     _commandQueue.Enqueue(command);
    // }
    // public void ExecuteCommands()
    // {
    //     if (_commandQueue.Count >0)
    //     {
    //         Command command = _commandQueue.Peek();
    //         if (command.IsCompleted())
    //         {
    //             _commandQueue.Dequeue();
    //         }
    //         else
    //         {
    //             command.Execute(gameObject);    
    //         }
    //     }
    // }

    
}
