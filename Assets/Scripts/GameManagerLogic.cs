using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;

public class GameManagerLogic : MonoBehaviour
{
    BallLogic _ball;
    public TextMeshPro score;
    public int counter;
    public bool gameRunning = true;
    string gameOverText = "Game Over - Final score : ";
    string restartText = "\nPress Z to restart";

    public void lose(){
        gameRunning = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _ball = GameObject.Find("Ball").GetComponent<BallLogic>();
        score = gameObject.GetComponent<TextMeshPro>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameRunning){
            score.text = gameOverText + counter.ToString() + restartText;
            if(Input.GetKey("z")){
                gameRunning = true;
                counter = 0;
                _ball._moveRight = false;
                score.text = counter.ToString();
            }
        } else{
            score.text = counter.ToString();
        }
    }
}
