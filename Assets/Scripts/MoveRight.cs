using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 right = Vector3.right;
        transform.Translate(right * _speed * Time.deltaTime);
        if (this.transform.position.x >= 14)
        {
            Destroy(this.gameObject);
        }
    }
}
