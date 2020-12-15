using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    private int count;
    private bool opening;
    private float timer;
    private float speed;

    public GameObject door1;
    private Vector3 door1_closePos;
    private Vector3 door1_openPos;

    public GameObject door2;
    private Vector3 door2_closePos;
    private Vector3 door2_openPos;

    private Vector3 doorGap;

    private void Start() {
        timer = 0;
        opening = false;
        
        door1_closePos = door1.transform.position;
        door2_closePos = door2.transform.position;
        doorGap = door2_closePos - door1_closePos;

        door1_openPos = door1_closePos - doorGap * 0.95f;
        door2_openPos = door2_closePos + doorGap * 0.95f;
    }

    private void Update() {
        
    }

    private void FixedUpdate() {
        if(count > 0) {
            door1.transform.position = door1_openPos; // TODO: Vector3.Slerp()
            door2.transform.position = door2_openPos; // TODO: Vector3.Slerp()
            //Vector3.Slerp(door1.transform.position, door1_openPos, 1);
        }
        else {
            door1.transform.position = door1_closePos; // TODO: Vector3.Slerp()
            door2.transform.position = door2_closePos; // TODO: Vector3.Slerp()
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            //Debug.Log("Player detected!");
            count++;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            //Debug.Log("Player missing!");
            count--;
        }
    }
}
