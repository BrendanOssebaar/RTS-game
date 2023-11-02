using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTypes : MonoBehaviour
{
    public enum ActionType
    {
        Move,
        Attack
    }
    [System.Serializable]
    public struct ActionCommandPair
    {
        public ActionType actionType;
        public ICommand command;
    }
}
