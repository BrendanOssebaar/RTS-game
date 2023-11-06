using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;


public class MoveCommand : Command
{
    public static Vector3 destination;
    private float speed = 5f;
    private Coroutine moveCoroutine;
    public MoveCommand(GameObject entity, Vector3 destination)
    {
        this.Target = entity;
        MoveCommand.destination = destination;
    }

    public GameObject Target { get; }

    public override bool IsCompleted()
    {
        if (Vector3.Distance(destination, Target.transform.position) < 0.1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Execute()
    {
       moveCoroutine = Target.GetComponent<MonoBehaviour>().StartCoroutine(MoveToDestination());
    }

    IEnumerator MoveToDestination()
    {
        while (Vector3.Distance(Target.transform.position , destination)>0.1f)
        {
            Vector3 direction = (destination - Target.transform.position).normalized;
            Target.transform.position += direction * speed * Time.deltaTime;
            yield return null;
        }
    }

    public override void Cancel()
    {
        if (moveCoroutine != null)
        {
            Target.GetComponent<MonoBehaviour>().StopCoroutine(moveCoroutine);
        }

        if (Input.GetKeyDown("s"))
        {
            Target.GetComponent<MonoBehaviour>().StopCoroutine(moveCoroutine);
        }
    }
}
// transform.position = Vector3.MoveTowards(entity.transform.position, destination, speed * Time.deltaTime);