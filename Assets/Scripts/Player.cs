using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    new public Camera camera;
    public List<Task> tasks;
    public Task currentTask;

    public enum CrewmateOrImposter {
        Crewmate, Imposter
    }
    public CrewmateOrImposter team;

    //public Rigidbody rigidbody;
    private bool E_pressed;
    public bool action;

    private void Start() {
        
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (!E_pressed) {
                action = true;
            }
            E_pressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.E)) {
            E_pressed = false;
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
            interactable.Interact(this);
            Debug.Log("Player: Interacting!");
        }
    }
}
