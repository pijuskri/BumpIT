using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour {
    public List<Transform> carList;
    Vector2 middle;
    float height = 10;
    // Use this for initialization
    void Start () {
        List<Transform> carList = new List<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
        float x = 0, y = 0;
        foreach (var car in carList)
        {
            x += car.position.x;
            y += car.position.z;
        }
        middle = new Vector2(x / carList.Count, y/carList.Count);
        float max = -1;
        foreach (var car in carList)
        {
            float distance = Vector2.Distance(middle, new Vector2(car.position.x, car.position.z));
            if (distance > max) max = distance;
        }
        height = max + 10;
        transform.position = new Vector3(middle.x, height, middle.y-5);
	}
}
