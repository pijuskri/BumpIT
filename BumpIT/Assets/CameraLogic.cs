using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour {
    public List<GameObject> carList;
    Vector2 middle;
    float height = 10;
    // Use this for initialization
    void Start () {
        //List<Transform> carList = new List<Transform>();
        transform.rotation = Quaternion.Euler(65,0,0);
    }
	
	// Update is called once per frame
	void Update () {
        float x = 0, y = 0;
        //carList.TrimExcess();
        foreach (var car in carList)
        {
            
            x += car.transform.position.x;
            y += car.transform.position.z;
        }
        middle = new Vector2(x / carList.Count, y/carList.Count);
        float max = -1;
        foreach (var car in carList)
        {
            float distance = Vector2.Distance(middle, new Vector2(car.transform.position.x,
                car.transform.position.z));
            //Debug.Log( car.GetComponent<Movement>().player + "-" + distance);
            if (distance > max) max = distance;
        }
        height = max*1.5f + 3;
        transform.position = new Vector3(middle.x, height, middle.y-height/2-1);
	}
}
