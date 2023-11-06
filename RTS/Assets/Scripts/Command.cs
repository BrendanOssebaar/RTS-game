using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public abstract class Command /*: MonoBehaviour*/
{
    public abstract void Execute();
    public abstract void Cancel();
    public GameObject Target { get; }
    public abstract bool IsCompleted();

}