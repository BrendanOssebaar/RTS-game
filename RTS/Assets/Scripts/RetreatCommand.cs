using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatCommand : ICommand
{
    public void Execute()
    {
        Debug.Log("Make the units retreat");
    }
    public GameObject Target { get; }
    public void Cancel()
    {
        
    }
}
