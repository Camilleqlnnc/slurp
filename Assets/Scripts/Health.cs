using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] IntVariable _playerStartHP;
    [SerializeField] IntVariable _playerCurrentHP;
    // Start is called before the first frame update
    void Awake()
    {
        
        if (_playerCurrentHP != null)
        {
            _playerCurrentHP._value = _playerStartHP._value;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerCurrentHP._value == 0)
        {
            Debug.Log("GAME OVER");
        }
    }

}
