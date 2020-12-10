using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallButton : MonoBehaviour {
    public Elevator elevator;
    public Vector3 callPos;

    public enum Floor {
        Lower, Upper
    }
    public Floor floor;

    private void Start() {
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Player") {
            if (other.GetComponent<Player>().action) {
                elevator.Call(callPos, floor); // TODO: Vector3.Slerp()
                Debug.Log("Called elevator!");
            }
        }
    }


}
