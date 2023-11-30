using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInputHandler : MonoBehaviour
{
    [SerializeField] private Commander commander;
    private Unit _selectedUnit;
    public Array[] excludedLayers;

    private RaycastHit? CalculateRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // _selectedUnit = hit.collider.GetComponent<Unit>();
            // if (_selectedUnit != null)
            // {
                return hit;
            // }
        }

        return null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hitInfo = CalculateRaycast();
            if (hitInfo.Value.collider.isTrigger)
            {
                Debug.Log("Did not Hit Anything, deselecting");
                commander.DeselectEntity();
            }
            if (hitInfo.HasValue)
            {
                commander.addToSelection(hitInfo.Value.collider.gameObject);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right-click detected");
            if (commander.selectedEntities.Count < 1)
            {
                Debug.Log("No units selected");
                return;
            }
            var hitInfo = CalculateRaycast();
            if (hitInfo.HasValue)
            {
                Debug.Log($"Issuing command to position {hitInfo.Value.point}");
                commander.IssueCommand(hitInfo.Value.point);   
            }
        }
    }

    // private void IssueCommandToSelectedUnit(Vector3 destination)
    // {
    //     commander.IssueCommand(destination);
    // }
    // void SelectEntity()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;
    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         _selectedUnit = hit.collider.GetComponent<Unit>();
    //         if (_selectedUnit != null)
    //         {
    //             Debug.Log("Entity Selected: " + _selectedUnit.gameObject.name);
    //         }
    //     }
    // }

    // void IssueCommand()
    // {
    //     if (_selectedUnit == null) return;
    //
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;
    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         commander.IssueCommand(hit.point);
    //     }
    // }
    // void SelectEntity()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     if (!Physics.Raycast(ray, out var hit)) return;
    //     _selectedUnit = hit.collider.GetComponent<Unit>();
    //     if (_selectedUnit != null)
    //     {
    //         commander.SelectEntity(hit.collider.gameObject);
    //     }
    //     // Debug.Log("Entity Selected: " + hit.transform.name);
    // }

    // void IssueCommand()
    // {
    //     commander.IssueCommand(_selectedUnit, hit.point);
    //     // print(MoveCommand.destination);
    // }
}

    
