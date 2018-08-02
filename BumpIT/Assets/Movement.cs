using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody rigid;
    float speed = 1000;
    float maxSpeed = 10;
    float rotationSpeed = 50f;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(-transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,-1,0) * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * rotationSpeed * Time.deltaTime);
        }

        //transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y, 0);
        //if (rigid.velocity.magnitude > maxSpeed) rigid.velocity = new Vector3(rigid.velocity.);
    }
}
