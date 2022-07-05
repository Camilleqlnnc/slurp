using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private float _moveSpeed = 10f;
    [SerializeField]
    private Animator _animator;

    #endregion

    #region Unity Lifecycle

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        ProcessInput();
    }

    void FixedUpdate()
    {
        Move();
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

        if(_directionInput.x < 0 || _directionInput.x > 0)
        {
            _animator.SetBool("isRunningUp", false);
            _animator.SetBool("isRunningDown", false);
            _animator.SetBool("isRunning", true);
        }
        if (_directionInput.y > 0)
        {
            _animator.SetBool("isRunningUp", true);
            _animator.SetBool("isRunningDown", false);
            _animator.SetBool("isRunning", false);
        }
        if (_directionInput.y < 0)
        {
            _animator.SetBool("isRunningDown", true);
            _animator.SetBool("isRunningUp", false);
            _animator.SetBool("isRunning", false);
        }
        if (_directionInput.y == 0)
        {
            _animator.SetBool("isRunningDown", false);
            _animator.SetBool("isRunningUp", false);
        }
        if (_directionInput.x == 0)
        {
            _animator.SetBool("isRunning", false);
        }
    }
    #endregion

    #region Privates & Protected
    private Vector2 _directionInput;
    private Rigidbody2D _rigidbody;
    #endregion

}
