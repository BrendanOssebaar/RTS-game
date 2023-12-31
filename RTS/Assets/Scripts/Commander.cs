using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            obj.GetComponent<Unit>().particleSystem.Play();
            obj.GetComponent<Unit>().isSelected = true;
        }
        
    }
    public void DeselectEntity()
    {
        // if (selectedEntities.Count == 0)return;
        Debug.Log("Entity Deselected: " + selectedEntities);
        foreach (var obj in selectedEntities)
        {
            obj.GetComponent<Unit>().particleSystem.Stop();
            obj.GetComponent<Unit>().isSelected = false;
        }
        selectedEntities.Clear();
    }

    public void selectedEntitiesInArea(Vector3 start, Vector3 end)
    {
        Bounds selectionBounds = new Bounds();
        selectionBounds.SetMinMax(Vector3.Min(start,end),Vector3.Max(start,end));
        Collider[] colliders = Physics.OverlapBox(selectionBounds.center, selectionBounds.extents);
        foreach (var collider in colliders)
        {
            Unit unitComponent = collider.gameObject.GetComponent<Unit>();
            if (unitComponent != null)
            {
                selectedEntities.Add(collider.gameObject);
            }
        }
    }
    public void IssueCommand(Vector3 destination)
    {
        if (selectedEntities.Count < 1)
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
