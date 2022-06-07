using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{   
    public enum State{
        OPEN,
        CLOSED
    }

    public State state;
    public bool openable;
    

    public abstract void Interact();

}
