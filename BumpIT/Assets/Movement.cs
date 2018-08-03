using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody rigid;

    float speed = 600;
    float maxSpeed = 10;
    float rotationSpeed = 120f;

    public char Foward;
    public char Back;
    public char Left;
    public char Right;

    public Transform center;

    bool onGround = false;

    public int player;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
        Color setColor = new Color();
        switch (player)
        {
            case 0:
                setColor = Color.blue;
                break;
            case 1:
                setColor = Color.red;
                break;
            case 2:
                setColor = Color.yellow;
                break;
            default:
                setColor = Color.white;
                break;
        }
        GetComponentInChildren<MeshRenderer>().material.color = setColor;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.rotation.eulerAngles.z > 160 && 
            transform.rotation.eulerAngles.z < 200 && onGround) Respawn();

        if (Vector3.Distance(transform.position, center.transform.position) > 30) Respawn();   

        if (Input.GetKey((KeyCode)(int)Foward) && onGround)
        {
            rigid.AddForce(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey((KeyCode)(int)Back) && onGround)
        {
            rigid.AddForce(-transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey((KeyCode)(int)Left))
        {
            transform.Rotate(new Vector3(0,-1,0) * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey((KeyCode)(int)Right))
        {
            transform.Rotate(new Vector3(0, 1, 0) * rotationSpeed * Time.deltaTime);
        }

        //transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y, 0);
        //if (rigid.velocity.magnitude > maxSpeed) rigid.velocity = new Vector3(rigid.velocity.);
    }
    private void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            onGround = true;
        }
        else onGround = false;
    }
    void Respawn()
    {
        transform.position = new Vector3(Random.Range(-5, 5), 3, Random.Range(-5, 5));
        GetComponent<Rigidbody>().velocity = new Vector3();
        transform.rotation = new Quaternion();
        GetComponent<Rigidbody>().angularVelocity = new Vector3();
        onGround = false;
    }
    
}
