using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    public GameObject pad;
    public ElevDoors lowerDoors;
    public ElevDoors upperDoors;

    enum State {
        LowerFloor, GoingUp, UpperFloor, GoingDown
    }
    State state;

    //ElevatorDoors lower_elevDoors;
    //ElevatorDoors upper_elevDoors;

    public void Call(Vector3 callPos, CallButton.Floor floor) { // calling elevator down
        if(floor == CallButton.Floor.Lower && state == State.UpperFloor) {
            pad.transform.position = callPos; // TODO: Vector3.Slerp()
            lowerDoors.OpenDoors();
        }
        else if(floor == CallButton.Floor.Upper && state == State.LowerFloor) { // calling elevator up
            pad.transform.position = callPos; // TODO: Vector3.Slerp()
            upperDoors.OpenDoors();
        }
    }
}
