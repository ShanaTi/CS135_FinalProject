using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedBayScanner : MonoBehaviour
{


       private int increment = 0;
       public int loopHeight = 21;

    void Update()
    {
        //get the Input from Horizontal axis
        //float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        //float verticalInput = Input.GetAxis("Vertical");
        //update the position
        //float verticalInput = Input.GetAxis("Vertical");
        //float horizontalInput = Input.GetAxis("Horizontal");
        //transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);
        increment = increment + 1;
        if (increment > 21)
        {
            increment = 0;
        }
            transform.position = transform.position + new Vector3(0, increment, 0);

    }
}
