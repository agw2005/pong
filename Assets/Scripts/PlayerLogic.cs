using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    GameManagerLogic _gameManager;
    Rigidbody2D _rigidBody;
    float _inputVertical;
    [SerializeField] float _playerSpeed = 500f;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerLogic>();
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputVertical = Input.GetAxisRaw("Vertical");
        if (_inputVertical != 0 && _gameManager.gameRunning)
        {
            _rigidBody.AddForce(new Vector2(0, _inputVertical * _playerSpeed));
        }
    }
}
