using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    private Vector3 spin;
    public Rigidbody rigidbody;

    private void Start() {
        spin.x = Random.Range(.5f, 5);
        spin.y = Random.Range(.5f, 5);
        spin.z = Random.Range(.5f, 5);
        //rigidbody =  GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        this.transform.Rotate(spin);
    }
    /*
    private void OnCollisionEnter(Collision collision) {
        //Debug.Log("Asteroid: Collision");
        if (collision.gameObject.tag == "Window") {
            Debug.Log("Asteroid destroyed itself!");
            Destroy(this.gameObject);
        }
    }
    */
    ///*
    private void OnTriggerEnter(Collider other) {
        //Debug.Log("Trigger");
        if(other.gameObject.tag == "Window") {
            Debug.Log("Asteroid destroyed itself!");
            Destroy(this.gameObject);
        }
    }
    //*/

    private void Explode() {
        foreach(Transform child in this.transform) {
            child.transform.parent = null;
        }
    }
}
