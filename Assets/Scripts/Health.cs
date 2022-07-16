using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] IntVariable _playerStartHP;
    [SerializeField] IntVariable _playerCurrentHP;
    [SerializeField]
    GameObject _gameOver;
    [Header("Life")]
    [SerializeField]
    GameObject _loseHP1;
    [SerializeField]
    GameObject _loseHP2;
    [SerializeField]
    GameObject _loseHP3;
    [SerializeField]
    GameObject _loseHP4;
    [SerializeField]
    GameObject _loseHP5;

    // Start is called before the first frame update
    void Awake()
    {
        
        if (_playerCurrentHP != null)
        {
            _playerCurrentHP._value = _playerStartHP._value;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_playerCurrentHP._value == 4)
        {
            _loseHP1.SetActive(true);
        }
        else if(_playerCurrentHP._value == 3)
        {
            _loseHP2.SetActive(true);
        }
        else if (_playerCurrentHP._value == 2)
        {
            _loseHP3.SetActive(true);
        }
        else if (_playerCurrentHP._value == 1)
        {
            _loseHP4.SetActive(true);
        }
        else if (_playerCurrentHP._value == 0)
        {
            _loseHP5.SetActive(true);
            Debug.Log("GAME OVER");
            _gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
