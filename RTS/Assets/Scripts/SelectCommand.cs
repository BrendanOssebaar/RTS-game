using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCommand : Command
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Execute()
    {
        SelectEntity();
    }

    public override void Cancel()
    {
        
    }

    public override bool IsCompleted()
    {
        return true;
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
