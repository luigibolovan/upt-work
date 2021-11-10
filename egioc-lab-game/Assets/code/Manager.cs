using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public static Manager   instance;
    public Text             scoreText;
    public Text             livesText;
    public GameObject       gameOverPanel;
    public Text             finalScoreText;

    int score   = 0;
    bool over   = false;
    int lives   = 3;
    

    private void Awake()
    {
        instance = this;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void incrementTheScore(){
        if (false == over){
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void decreaseLife() {
        if(lives > 0) {
            lives--;
            livesText.text = lives.ToString();
        }

        if(lives <= 0){
            over = true;
            livesText.text = lives.ToString();
            finalScoreText.text = score.ToString();
            endGame();
        }
    }

    public void endGame(){

        CandySpawner.instance.stopSpawning();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverPanel.SetActive(true);
    }



    public void restart() {
        SceneManager.LoadScene("Game");
    }

    public void backToMenu() {
        SceneManager.LoadScene("Menu");
    }

}
