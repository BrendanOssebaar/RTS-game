using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInputHandler : MonoBehaviour
{
    [SerializeField] private GameObject selectedEntity;
    // public Transform enemyTransform;
    [SerializeField] private Unit unit;
    private Command currentCommand = null;
    public List<ActionTypes.ActionCommandPair> actionCommandPairs;
    private Dictionary<GameObject, ActionTypes.ActionCommandPair> actionDictionary;
    private void Start()
    {
        actionDictionary = new Dictionary<GameObject, ActionTypes.ActionCommandPair>();
        foreach (var pair in actionCommandPairs)
        {
            actionDictionary.Add(pair.Command.Target, pair);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           SelectEntity();
        }

        else if (Input.GetMouseButtonDown(1) && selectedEntity != null)
        {
            IssueCommand();
        }
    }

    void SelectEntity()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit)) return;
        Unit unit = hit.collider.GetComponent<Unit>();
        if (unit != null)
        {
            selectedEntity = unit.gameObject;
            Debug.Log("Entity Selected: " + hit.transform.name);
        }
    }

    void IssueCommand()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit)) return;
        if (currentCommand != null)
        {
            currentCommand.Cancel();
        }
        if (actionDictionary.TryGetValue(hit.transform.gameObject, out ActionTypes.ActionCommandPair actionCommandPair))
        {
            currentCommand = actionCommandPair.Command;
        }
        else
        {
            currentCommand = new MoveCommand(selectedEntity, hit.point);
        }
        currentCommand.Execute();
        unit.EnqueueCommand(currentCommand);
        print(MoveCommand.destination);
    }
    //
    // private Vector3 getWorldPositionFromMouse()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;
    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         if (hit.transform.CompareTag("SelectableEntity"))
    //         {
    //             Debug.Log("Entity Selected:" + hit.transform.name);
    //         }
    //         // return hit.point;
    //     }
    //     // return Vector3.zero;
    // }
}
