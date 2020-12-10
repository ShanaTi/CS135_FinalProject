using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public enum CrewmateOrImposter {
        Crewmate, Imposter
    }
    public CrewmateOrImposter team;

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
        
    }
}
