using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    GameManagerLogic _gameManager;
    Rigidbody2D _rigidBody;
    bool _moveUp = true;
    public bool _moveRight = false;
    float _ballSpeed = 50f;

    void handleMovementHorizontal(bool movingRight, GameManagerLogic gameManagerInstance, float ballSpeed){
        if (movingRight && gameManagerInstance.gameRunning)
        {
            _rigidBody.AddForce(new Vector2(ballSpeed, 0));
        } else if(!movingRight && gameManagerInstance.gameRunning){
            _rigidBody.AddForce(new Vector2(-ballSpeed, 0));
        }
    }

    void handleMovementVertical(bool movingUp, GameManagerLogic gameManagerInstance, float ballSpeed){
        if (movingUp && gameManagerInstance.gameRunning)
        {
            _rigidBody.AddForce(new Vector2(0, ballSpeed));
        } else if(!movingUp && gameManagerInstance.gameRunning){
            _rigidBody.AddForce(new Vector2(0, -ballSpeed));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerLogic>();
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            _moveUp = !_moveUp;
        } else if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            _moveRight = !_moveRight;
        } else if(collision.gameObject.name == "Enemy Goal")
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
            _moveRight = false;
            _gameManager.counter++;
        } else if(collision.gameObject.name == "Player Goal")
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
            _gameManager.lose();
        }
    }

    void Update()
    {
        handleMovementVertical(_moveUp, _gameManager, _ballSpeed);
        handleMovementHorizontal(_moveRight, _gameManager, _ballSpeed);
    }
}
