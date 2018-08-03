using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    int playerCount;
    public Text playerCountText;
    public Slider slider;
    bool go = false;
    //public Text playerCountDisplay
	// Use this for initialization
	void Start () {
        playerCount = 2;
	}
	
	// Update is called once per frame
	void Update () {
        playerCount = (int)slider.value;
        playerCountText.text = "Player count:" + playerCount;

        if (SceneManager.GetSceneByName("game").isLoaded)
        {
            
        } 
    }
    public void GoToNextScene()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Additive);
        go = true;

        List<GameObject> cars = new List<GameObject>();
        cars.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        Debug.Log(cars.Count);
        if (playerCount == 3)
        {
            cars[3].SetActive(false);
        }
        if (playerCount == 2)
        {
            cars[3].SetActive(false);
            cars[2].SetActive(false);
        }


        GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>().playerCount = playerCount;
        SceneManager.UnloadSceneAsync("menu");
    }
    
}
