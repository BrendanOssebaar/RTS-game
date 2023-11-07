using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{
    private GameObject entity;
    private GameObject target;
    private bool isCompleted;

    public AttackCommand(GameObject entity, GameObject target)
    {
        this.entity = entity;
        this.target = target;
    }
    public GameObject Target { get; }
    public override bool Execute(GameObject Entity)
    {
        return isCompleted;
    }

    public override void Cancel()
    {
        
    }

    public override bool IsCompleted()
    {
        return isCompleted;
    }
}
