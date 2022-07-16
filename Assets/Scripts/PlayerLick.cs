using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLick : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private SpriteRenderer _playerSpriteRenderer;

    public AudioSource _lickAudio;
    #endregion

    #region Unity Lifecycle

    void Awake()
    {
        _tongueTransform = GetComponent<Transform>();
        _tonguePositionX = _tongueTransform.position.x;
    }

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("Lick", true);
            _lickAudio.Play();

        }
        else
        {
            _animator.SetBool("Lick", false);
        }
    }

    void FixedUpdate()
    {
        
    }

    #endregion

    #region Main Methods
 
    #endregion

    #region Privates & Protected
    private SpriteRenderer _spriteRenderer;
    private Transform _tongueTransform;
    private float _tonguePositionX;
    #endregion
}
