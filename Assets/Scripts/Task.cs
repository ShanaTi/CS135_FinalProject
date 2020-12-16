using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour, I_Interactable {
    public Player player;

    public enum State {
        Idle, Active, Complete
    };
    public State state;
    
    public void Interact(Player p) {
        Debug.Log("Task: Interact()");
        if (!player && !p.currentTask) {
            Debug.Log("Task: Interact(): !player");
            this.player = p;
            if (state == State.Idle) {
                StartTask();
                p.action = false;
            }
            p.currentTask = this;
            Debug.Log("Task started!");
        }
        else if (player && p.currentTask) { // player variable already set; a Player is currently interacting with this Task
            if(player == p && state == State.Active) {
                ExitTask();
                p.currentTask = null;
                p.action = false;
                player = null;
                //state = State.Idle;
            }
            Debug.Log("Task ended!");
        }
    }

    protected abstract void StartTask();
    protected abstract void ExitTask();
    protected abstract void CompleteTask();
}
