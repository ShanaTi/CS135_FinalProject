using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Task {
    public Vector3 playerDock;

    override protected void StartTask() {
        Rigidbody rigidbody = player.GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        player.transform.position = playerDock;
        state = State.Active;
    }

    override protected void ExitTask() {

    }

    override protected void CompleteTask() {
        player = null;
    }

    private void FixedUpdate() {
        if(state == State.Active) {

        }
    }
}
