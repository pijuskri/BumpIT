using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    int playerCount;
    public Text playerCountText;
    public Slider slider;
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
            GameLogic gameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
            gameLogic.playerCount = playerCount;

            List<GameObject> cars = gameLogic.cars;
            if (playerCount == 3)
            {
                cars[3].SetActive(false);
                gameLogic.scoreDisplay[3].gameObject.SetActive(false);
                cars.RemoveAt(3);
                
            }
            if (playerCount == 2)
            {
                cars[3].SetActive(false);
                cars[2].SetActive(false);
                gameLogic.scoreDisplay[3].gameObject.SetActive(false);
                gameLogic.scoreDisplay[2].gameObject.SetActive(false);
                cars.RemoveAt(3);
                cars.RemoveAt(2);
            }
            cars.TrimExcess();



            SceneManager.UnloadSceneAsync("menu");
        } 
    }
    public void GoToNextScene()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Additive);
    }
   
}
