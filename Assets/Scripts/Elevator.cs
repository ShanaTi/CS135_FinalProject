using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    public GameObject pad;
    public ElevDoors lowerDoors;
    public ElevDoors upperDoors;

    public enum State {
        LowerFloor, GoingUp, UpperFloor, GoingDown
    }
    public State state;

    //ElevatorDoors lower_elevDoors;
    //ElevatorDoors upper_elevDoors;

    public void Call(Vector3 callPos, CallButton.Floor floor) { // calling elevator down
        Debug.Log("Elevator: Call()");
        if(floor == CallButton.Floor.Lower && state == State.UpperFloor) {
            pad.transform.position += callPos; // TODO: Vector3.Slerp()
            lowerDoors.OpenDoors();
            state = State.LowerFloor;
            Debug.Log("Calling down elevator!");
        }
        else if(floor == CallButton.Floor.Upper && state == State.LowerFloor) { // calling elevator up
            pad.transform.position += callPos; // TODO: Vector3.Slerp()
            upperDoors.OpenDoors();
            state = State.UpperFloor;
            Debug.Log("Calling up elevator!");
        }
    }
}
