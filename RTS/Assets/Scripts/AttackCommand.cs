using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{
    private GameObject entity;
    private GameObject target;

    public AttackCommand(GameObject entity, GameObject target)
    {
        this.entity = entity;
        this.target = target;
    }
    public GameObject Target { get; }
    public override void Execute()
    {
        
    }

    public override void Cancel()
    {
        
    }

    public override bool IsCompleted()
    {
        return true;
    }
}
