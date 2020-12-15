using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour, I_Interactable {
    public Player player;

    public enum State {
        Idle, Active, Complete
    };
    protected State state;
    
    public void Interact(Player p) {
        if (!player) {
            this.player = p;
            if (state == State.Idle) {
                StartTask();
            }
            else if (state == State.Active) {
                ExitTask();
                player = null;
            }
        }
    }

    protected abstract void StartTask();
    protected abstract void ExitTask();
    protected abstract void CompleteTask();
}
