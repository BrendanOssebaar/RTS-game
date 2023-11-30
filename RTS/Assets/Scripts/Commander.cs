using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    public List<GameObject> selectedEntities = new List<GameObject>();
    private GameObject selectedEntity;
    private Command currentCommand;
    private Command newMoveCommand;
    private Unit _unit;
    

    // public void SelectEntity(GameObject entity)
    // {
    //     if (entity.GetComponent<Unit>() != null)
    //     {
    //         if (selectedEntity != null)
    //         {
    //             DeselectEntity();
    //         }
    //         selectedEntities.Add(gameObject);
    //         Debug.Log("Entity Selected: " + entity.name);
    //     }
    // }
    public void addToSelection(GameObject obj)
    {
        if (!selectedEntities.Contains(obj))
        {
            selectedEntities.Add(obj);
        }
    }
    public void DeselectEntity()
    {
        Debug.Log("Entity Deselected: " + selectedEntity.name);
        selectedEntities.Clear();
    }

    public void IssueCommand(Vector3 destination)
    {
        if (selectedEntities.Count <= 1)
        {
            Debug.LogWarning("No entity selected to issue command to.");
            return;
        }

        foreach (GameObject obj in selectedEntities)
        {
            _unit = obj.GetComponent<Unit>();
        }
        
        if (_unit == null)
        {
            Debug.LogError("Selected entity does not have a Unit component.");
            return;
        }
        
        if (currentCommand != null)
        {
            currentCommand.Cancel();
            currentCommand = null;
        }

        foreach (var VARIABLE in selectedEntities)
        {
            newMoveCommand = new MoveCommand(VARIABLE.transform,destination);
        }
        
        _unit.ExecuteCommand(newMoveCommand);
        currentCommand = newMoveCommand;

        }
    
    // public void IssueCommand(Unit unit, Vector3 destination)
    // {
    //     if (selectedEntity == null) return;
    //     Transform entityTransform = selectedEntity.transform;
    //     Command newMoveCommand = new MoveCommand(unit.transform, destination);
    //     // currentCommand = new MoveCommand(entityTransform, destination);
    //     // currentCommand.Execute(gameObject);
    //     unit.ExecuteCommand(newMoveCommand);
    //     Debug.Log("Command Issued: Moving " + selectedEntity.name + " to " + destination);
    // }
}
