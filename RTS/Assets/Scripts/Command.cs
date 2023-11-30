using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ScriptableObject
{
    public abstract bool Execute(GameObject entity);
    public abstract void Cancel();
    public GameObject Target { get; }
    public abstract bool IsCompleted();

}