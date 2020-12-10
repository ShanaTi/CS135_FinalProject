using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevDoors : MonoBehaviour {
    public GameObject elevDoor1;
    public Vector3 elevDoor1_closePos;
    public Vector3 elevDoor1_openPos;

    public GameObject elevDoor2;
    public Vector3 elevDoor2_closePos;
    public Vector3 elevDoor2_openPos;

    public void OpenDoors() {
        elevDoor1.transform.position = elevDoor1_openPos; // TODO
        elevDoor2.transform.position = elevDoor2_openPos;
    }

    public void CloseDoors() {
        elevDoor1.transform.position = elevDoor1_closePos; // TODO
        elevDoor2.transform.position = elevDoor2_closePos;
    }
}
