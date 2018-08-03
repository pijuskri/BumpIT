using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    int playerCount = 2;

    public int[] scoreList;
    public int[] deaths;

    public List<GameObject> cars;

    public GameObject AICar;
    public CameraLogic cameraLogic;
    // Use this for initialization
    void Start () {
        scoreList = new int[4];
        deaths = new int[5];

        cars = new List<GameObject>();
        cars.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        cars.TrimExcess();

        for (int i = 0; i < 0; i++)
        {
            Vector2 cord = Random.insideUnitCircle * 18;
            GameObject temp = Instantiate(AICar, new Vector3(cord.x, 7, cord.y), new Quaternion());
            cars.Add(temp);
        }
        

        cameraLogic.carList = cars;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
