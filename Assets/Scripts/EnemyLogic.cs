using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    GameManagerLogic _gameManager;
    Rigidbody2D _rigidBody;
    bool _moveUp = true;
    float _enemySpeed = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerLogic>();
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveUp && _gameManager.gameRunning)
        {
            _rigidBody.AddForce(new Vector2(0, _enemySpeed));
        } else if(!_moveUp && _gameManager.gameRunning){
            _rigidBody.AddForce(new Vector2(0, -_enemySpeed));
        } else{
            _rigidBody.velocity = new Vector2(0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            _moveUp = !_moveUp;
        }
    }
}
