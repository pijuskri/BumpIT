using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public GameObject box;
    public GameObject smallBox;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 15; i++)
        {
            Vector2 temp = Random.insideUnitCircle * 18;
            Instantiate(box, new Vector3(temp.x, 7, temp.y), new Quaternion());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
