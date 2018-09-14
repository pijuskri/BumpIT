using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public int playerCount = 4;

    public int[] scoreList;
    public int[] deaths;

    public List<GameObject> cars;

    public GameObject AICar;
    public CameraLogic cameraLogic;
    public Text[] scoreDisplay;
    public GameObject box;

    bool boxesSpawned = false;
    // Use this for initialization
    void Start () {
        scoreList = new int[4];
        deaths = new int[4];

        //cars = new List<GameObject>();
        //cars.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        //cars.TrimExcess();

        for (int i = 0; i < 0; i++)
        {
            Vector2 cord = Random.insideUnitCircle * 18;
            GameObject temp = Instantiate(AICar, new Vector3(cord.x, 7, cord.y), new Quaternion());
            cars.Add(temp);
        }
        //cars[0].SetActive(false);

        
        cameraLogic.carList = cars;

        
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < playerCount; i++)
        {
            scoreDisplay[i].text = scoreList[i].ToString();
        }
        if (SceneManager.GetSceneByName("menu").isLoaded == false && !boxesSpawned)
        {
            cameraLogic.carList = cars;
            for (int i = 0; i < 15; i++)
            {
                Vector2 temp = Random.insideUnitCircle * 18;
                Instantiate(box, new Vector3(temp.x, 7, temp.y),
                    Quaternion.Euler(0, Random.Range(0, 360), 0));
            }
            boxesSpawned = true;
        }
    }
}
