using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInputHandler : MonoBehaviour
{
    [SerializeField] private Commander commander;
    private Unit _selectedUnit;
    public Array[] excludedLayers;
    private Camera _camera;
    private Vector3 _startPosition;


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

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hitInfo = CalculateRaycast();
            if (!hitInfo.Value.collider.GetComponent<Unit>() && commander.selectedEntities.Count != 0)
            {
                // Debug.Log("Did not hit anything selectable, deselecting");
                commander.DeselectEntity();
            }
            if (hitInfo.Value.collider.GetComponent<Unit>())
            {
                commander.addToSelection(hitInfo.Value.collider.gameObject);
            }

            _startPosition = GetworldPosition(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            commander.selectedEntitiesInArea(_startPosition,GetworldPosition(Input.mousePosition));
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

    private Vector3 GetworldPosition(Vector2 screenPosition)
    {
        Ray ray = _camera.ScreenPointToRay(screenPosition);
        if (new Plane(Vector3.up,Vector3.zero).Raycast(ray, out float enter))
        {
            return ray.GetPoint(enter);
        }

        return Vector3.zero;
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

    
