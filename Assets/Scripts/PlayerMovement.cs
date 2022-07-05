using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private float _moveSpeed = 10f;


    #endregion

    #region Unity Lifecycle

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        ProcessInput();
    }

    void FixedUpdate()
    {
        Move();
        BoundPlayer();
    }

    #endregion

    #region Main Methods
    void ProcessInput()
    {
        _directionInput.x = Input.GetAxisRaw("Horizontal");
        _directionInput.y = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        _rigidbody.velocity = _directionInput * _moveSpeed;
    }

   

    private void BoundPlayer()
    {
        if (transform.position.x <= boundXLeft)
        {
            transform.position = new Vector3(boundXLeft, transform.position.y, 0);
        }
        else if (transform.position.x >= boundXRight)
        {
            transform.position = new Vector3(boundXRight, transform.position.y, 0);

        }
        else if (transform.position.y <= boundYBottom)
        {
            transform.position = new Vector3(transform.position.x, boundYBottom, 0);
        }
        else if (transform.position.y >= boundYTop)
        {
            transform.position = new Vector3(transform.position.x, boundYTop, 0);
        }
    }

    #endregion

    #region Privates & Protected
    private Vector2 _directionInput;
    private Rigidbody2D _rigidbody;
    private float boundXLeft = -30f;
    private float boundXRight = 91f;
    private float boundYBottom = -53f;
    private float boundYTop = 28.5f;
    #endregion

}
