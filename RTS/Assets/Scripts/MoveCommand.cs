using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;


public class MoveCommand : Command
{
    public Vector3 destination;
    private float speed = 5f;
    private Coroutine moveCoroutine;
    private bool isCompleted;
    private Transform entityTransform;
    public MoveCommand(Transform entityTransform, Vector3 destination)
    {
        this.entityTransform = entityTransform;
        this.destination = destination;
    }

    public override bool IsCompleted()
    {
        return isCompleted;
    }

    public override bool Execute(GameObject entity)
    {
        // if (Vector3.Distance(entity.transform.position, destination) > 0.1f)
        // {
        //     // entity.transform.position = Vector3.MoveTowards(entity.transform.position, destination, speed * Time.deltaTime);
        //     moveCoroutine = Target.GetComponent<MonoBehaviour>().StartCoroutine(MoveToDestination());
        //     isCompleted = false;
        // }
        // else
        // {
        //     isCompleted = true;
        // }
        if (moveCoroutine == null)
        {
            moveCoroutine = entityTransform.GetComponent<MonoBehaviour>().StartCoroutine(MoveToDestination());
        }
        return isCompleted;
        
    }

    IEnumerator MoveToDestination()
    {
        while (Vector3.Distance(entityTransform.position , destination)>0.1f)
        {
            Vector3 direction = (destination - entityTransform.position).normalized;
            entityTransform.position += direction * speed * Time.deltaTime;
            yield return null;
        }

        isCompleted = true;
        moveCoroutine = null;
    }

    public override void Cancel()
    {
        if (moveCoroutine != null)
        {
            entityTransform.GetComponent<MonoBehaviour>().StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
    }
}
// transform.position = Vector3.MoveTowards(entity.transform.position, destination, speed * Time.deltaTime);