using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 left = Vector3.left;
        transform.Translate(left * _speed * Time.deltaTime);

        if (this.transform.position.x <= -17)
        {
            Destroy(this.gameObject);
        }
    }
}
