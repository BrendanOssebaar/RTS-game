using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    private GameObject selectedEntity;
    private Command currentCommand;

    private Unit Unit;
    // public List<ActionTypes.ActionCommandPair> actionCommandPairs;
    // private Dictionary<GameObject, ActionTypes.ActionCommandPair> actionDictionary;

    // private void Start()
    // {
    //     actionDictionary = new Dictionary<GameObject, ActionTypes.ActionCommandPair>();
    //     foreach (var pair in actionCommandPairs)
    //     {
    //         actionDictionary.Add(pair.Command.Target, pair);
    //     }
    // }

    public void SelectEntity(GameObject entity)
    {
        if (entity.GetComponent<Unit>() != null)
        {
            if (selectedEntity != null)
            {
                DeselectEntity();
            }
            selectedEntity = entity;
            Debug.Log("Entity Selected: " + entity.name);
        }
    }
    private void DeselectEntity()
    {
        // You may want to add logic here to clean up or reset the state when an entity is deselected
        Debug.Log("Entity Deselected: " + selectedEntity.name);
        selectedEntity = null;
    }

    public void IssueCommand(Vector3 destination)
    {
        if (selectedEntity == null)
        {
            Debug.LogWarning("No entity selected to issue command to.");
            return;
        }
        Unit unit = selectedEntity.GetComponent<Unit>();
        if (unit == null)
        {
            Debug.LogError("Selected entity does not have a Unit component.");
            return;
        }
        
        if (currentCommand != null)
        {
            currentCommand.Cancel();
            currentCommand = null;
        }
        
        Command newMoveCommand = new MoveCommand(selectedEntity.transform,destination);
        unit.ExecuteCommand(newMoveCommand);
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
