using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    private GameObject entity;
    private GameObject target;

    public AttackCommand(GameObject entity, GameObject target)
    {
        this.entity = entity;
        this.target = target;
    }
    public void Execute()
    {
        
    }

    public void Cancel()
    {
        
    }
}
