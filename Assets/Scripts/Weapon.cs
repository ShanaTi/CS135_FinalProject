using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Task {
    public Transform playerDock;
    public Transform camTrans;
    public Transform turret;
    private Quaternion defaultRotation;

    override protected void StartTask() {
        //Rigidbody rigidbody = player.GetComponent<Rigidbody>();
        //rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        //player.transform.position = playerDock.position;
        camTrans = player.camera.transform;
        state = State.Active;
    }

    override protected void ExitTask() {
        turret.transform.rotation = defaultRotation; //Quaternion.Euler(new Vector3(-90, 90, 0));
        camTrans = null;
        state = State.Idle;
    }

    override protected void CompleteTask() {
        foreach(Task t in player.tasks) {
            if(t is Weapon) {
                player.tasks.Remove(t);
            }
        }
        player = null;
    }

    private void Start() {
        defaultRotation = turret.transform.rotation;
    }

    private void FixedUpdate() {
        if(state == State.Active) {
            float range = 30f;
            RaycastHit hit;

            Vector3 offset = new Vector3(-90, 90, -90); // Z, X, Y
            Vector3 aimPoint = player.transform.position + camTrans.forward * range;
            if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, range)) { // object detected by Raycast
                Debug.Log("Raycast: " + hit.transform.gameObject.tag + " detected!");
                if(hit.transform.gameObject.tag == "Shootable") { // Shootable detected
                    turret.transform.LookAt(hit.transform.position);
                    turret.transform.Rotate(offset);// = Quaternion.Euler(turret.transform.rotation.eulerAngles + offset);
                }
                /*
                else if(hit.transform.gameObject.tag == "Weapon") { // no Shootable within range
                    turret.transform.LookAt(aimPoint);
                    turret.transform.Rotate(offset);
                }
                */
            }
            else { // no Shootable within range
                turret.transform.LookAt(aimPoint);
                turret.transform.Rotate(offset);
            }

            if((this.transform.position - player.transform.position).magnitude > 7.5f) { // Player moved more than 5 units away from Weapon
                ExitTask();
                TaskEnd();
            }
        }
        else if(state == State.Complete) {
            CompleteTask();
            state = State.Idle;
        }
    }
}
