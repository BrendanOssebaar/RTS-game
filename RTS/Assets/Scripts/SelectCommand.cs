using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCommand : Command
{
    private bool isCompleted;
    public override bool Execute(GameObject entity)
    {
        SelectEntity();
        return isCompleted;
    }

    public override void Cancel()
    {
        
    }

    public override bool IsCompleted()
    {
        return isCompleted;
    }
    void SelectEntity()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit)) return;
        if (hit.transform.CompareTag("SelectableEntity"))
        {
            // MouseInputHandler.selectedEntity = hit.transform.gameObject;
            Debug.Log("Entity Selected: " + hit.transform.name);
        }
    }
}
