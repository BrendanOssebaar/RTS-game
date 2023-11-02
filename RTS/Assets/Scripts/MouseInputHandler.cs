using System;
using UnityEngine;

public class MouseInputHandler : MonoBehaviour
{
    [SerializeField] private GameObject selectedEntity;
    // public Transform enemyTransform;
    private ICommand currentCommand = null;
    public enum ActionType
    {
        Move,
        Attack
    }
    [Serializable]
    public struct ActionCommandPair
    {
        public ActionType actionType;
        public ICommand command;
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
        if (hit.transform.CompareTag("SelectableEntity"))
        {
            selectedEntity = hit.transform.gameObject;
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
        if (hit.transform.CompareTag("EnemyEntity"))
        {
            currentCommand = new AttackCommand(selectedEntity, hit.transform.gameObject);
        }
        else
        {
            currentCommand = new MoveCommand(selectedEntity, hit.point);
        }
        currentCommand.Execute();
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
