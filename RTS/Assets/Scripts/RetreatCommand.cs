using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatCommand : Command
{
    private bool isCompleted;
    public override bool Execute(GameObject entity)
    {
        Debug.Log("Make the units retreat");
        return isCompleted;
    }
    public GameObject Target { get; }
    public override void Cancel()
    {
        
    }

    public override bool IsCompleted()
    {
        return isCompleted;
    }
}
