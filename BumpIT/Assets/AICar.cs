using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : MonoBehaviour {

    List<GameObject> cars;
    GameLogic gameLogic;
	// Use this for initialization
	void Start () {
        // GameObject.FindGameObjectsWithTag();
        foreach (var car in gameLogic.cars)
        {
            if (car != gameObject) cars.Add(car);
        }
	}
	
	// Update is called once per frame
	void Update () {
        float min = 999;
        GameObject follow;
        //if()
	}
}
