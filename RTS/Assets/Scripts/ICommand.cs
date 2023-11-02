using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public interface ICommand
{
    void Execute();
    void Cancel();

}