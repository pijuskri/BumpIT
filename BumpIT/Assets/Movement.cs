using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody rigid;
    public GameLogic gameLogic;

    float speed = 600;
    float maxSpeed = 10;
    float rotationSpeed = 120f;



    public Transform center;

    bool onGround = false;

    public int player;

    GameObject lastHit;
    float timeSinceLastHit = 0;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
        lastHit = center.gameObject;
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
            case 3:
                setColor = Color.magenta;
                break;
            default:
                setColor = Color.white;
                break;
        }
        GetComponentInChildren<MeshRenderer>().material.color = setColor;
	}
	
	// Update is called once per frame
	void Update () {

        timeSinceLastHit += Time.deltaTime;

        if (transform.rotation.eulerAngles.z > 160 && 
            transform.rotation.eulerAngles.z < 200 && onGround) Respawn();

        if (Vector3.Distance(transform.position, center.transform.position) > 30) Respawn();   

        if (onGround)
        {
            rigid.AddForce(transform.forward * speed * Time.deltaTime * Input.GetAxis("Foward"+player));
        }

        transform.Rotate(new Vector3(0, 1, 0) * rotationSpeed * Time.deltaTime * Input.GetAxis("Side"+player));

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
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "AI")
        {
            lastHit = coll.gameObject;
            timeSinceLastHit = 0;
        }
    }
    void Respawn()
    {
        if (lastHit.tag == "Player" && timeSinceLastHit<4)
        {
            //Debug.Log(player);
            gameLogic.scoreList[lastHit.GetComponent<Movement>().player]++;
        }
        else if (gameLogic.scoreList[player] > 0) gameLogic.scoreList[player]--;

        gameLogic.deaths[player]++;
       

        transform.position = new Vector3(Random.Range(-7, 7), 3, Random.Range(-7, 7));
        GetComponent<Rigidbody>().velocity = new Vector3();
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        GetComponent<Rigidbody>().angularVelocity = new Vector3();
        onGround = false;
    }
    
}
