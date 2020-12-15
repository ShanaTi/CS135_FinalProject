using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public enum CrewmateOrImposter {
        Crewmate, Imposter
    }
    public CrewmateOrImposter team;

    //public Rigidbody rigidbody;
    public bool action;

    private void Start() {
        
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            action = true;
        }
        else if (Input.GetKeyUp(KeyCode.E)) {
            action = false;
        }
    }

    private void FixedUpdate() {
        if (action) {
            //Debug.Log("action button pressed!"); 
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Interactable" && action) {
            I_Interactable interactable = other.gameObject.GetComponent<I_Interactable>();
            interactable.Interact();
            Debug.Log("Player: Interacting!");
        }
    }
}
