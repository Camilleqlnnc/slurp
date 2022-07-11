using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionsPnj : MonoBehaviour
{    //Toutes les variables accessibles dans l'inspector
    #region Exposed

    #endregion

    #region Unity Life Cycle
    void Awake()
    {
        _bc2D = gameObject.GetComponent<BoxCollider2D>();
        _rb2D = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion
    //Toutes les fonctions créées par l'équipe
    #region Main Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tongue"))
        {
            _animator.SetBool("isHappy", true);
        }
    }

    #endregion

    //Les variables privées et protégées
    #region Private & Protected
    private SpriteRenderer _spritreRenderer;
    private Animator _animator;
    private BoxCollider2D _bc2D;
    private Rigidbody2D _rb2D;
    #endregion
}
