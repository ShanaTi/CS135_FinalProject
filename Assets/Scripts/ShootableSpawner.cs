using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableSpawner : MonoBehaviour {
    public Weapon weapon;
    public GameObject shootable;
    //public Transform shootableSpawn;
    public int destroyed;
    public float timer;
    public List<Asteroid> asteroids;

    private void Start() {
        destroyed = 0;
        timer = 0;
        asteroids = new List<Asteroid>();
        asteroids.Capacity = 10;
    }

    private void FixedUpdate() {
        if(weapon.state == Weapon.State.Active) { // Weapon active
            if(destroyed == 10) {
                weapon.state = Weapon.State.Complete;
            }
            else { // instantiate shootable objects
                if(timer >= 2 && asteroids.Count < asteroids.Capacity) { // timer at ~3 seconds
                    Vector3 offset = this.transform.position + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-15, 15));
                    GameObject asteroid = Asteroid.Instantiate(shootable, this.transform.position + offset, Quaternion.identity);
                    
                    Rigidbody ast_rb = asteroid.GetComponent<Rigidbody>();
                    Vector3 weaponOffset = new Vector3(0, Random.Range(-1, 1), Random.Range(-5, 5));
                    Vector3 destination = weapon.transform.position + weaponOffset;
                    Vector3 direction = destination - asteroid.transform.position;

                    ast_rb.velocity = direction / 5;
                    asteroid.gameObject.SetActive(true);
                    
                    timer = 0;
                }
                else { // increment timer
                    timer += Time.fixedDeltaTime;
                }
            }
        }
    }
}
