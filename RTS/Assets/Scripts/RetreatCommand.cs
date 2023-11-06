using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatCommand : Command
{
    public override void Execute()
    {
        Debug.Log("Make the units retreat");
    }
    public GameObject Target { get; }
    public override void Cancel()
    {
        
    }

    public override bool IsCompleted()
    {
        return true;
    }
}
