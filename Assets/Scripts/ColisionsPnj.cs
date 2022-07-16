using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionsPnj : MonoBehaviour
{    //Toutes les variables accessibles dans l'inspector
    #region Exposed
    [SerializeField] IntVariable _playerCurrentHP;
    
    [Header("Audio")]
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    AudioClip lastClip;

    [Header("Happy/Sad Sprite")]
    public Sprite _happySprite;
    [SerializeField] SpriteRenderer _happyIndicator;

    [Header("Shake Effect")]
    // Transform of the GameObject you want to shake
    private Camera mainCam;
    // Desired duration of the shake effect
    [SerializeField] private float _shakeAmount = 0f;

    [Header("Limit Detection")]
    [SerializeField]
    private Transform _limitChecker;
    [SerializeField]
    private float _limitCheckerRadius;
    [SerializeField]
    private LayerMask _limitMask;

    [SerializeField] private float camShakeAmount;
    [SerializeField] private float camShakeLength;
    #endregion

    #region Unity Life Cycle
    void Awake()
    {
        _happyIndicator.name = _happyIndicator.GetComponent<SpriteRenderer>().name;
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /* LimitCheck();
         Debug.Log(_isInLimit);
         if(_isInLimit && !isHappy)        
         {
             Debug.Log("en dehors de l'arène");
             _playerCurrentHP._value--;
             ShakeScreen(camShakeAmount, camShakeLength);
         }
        */
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(_limitChecker.position, _limitCheckerRadius);
    }
    #endregion
    //Toutes les fonctions créées par l'équipe
    #region Main Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tongue"))
        {
            ChangeSprite();
            randomSound.PlayOneShot(RandomClip());
        }
        else if (collision.gameObject.CompareTag("Limit") && !isHappy)
            {
                _playerCurrentHP._value--;
                ShakeScreen(camShakeAmount, camShakeLength);
            }
    }

    public AudioClip RandomClip()
    {
        int attempts = 3;
        AudioClip newClip = audioSources[Random.Range(0, audioSources.Length)];
        while (newClip == lastClip && attempts > 0)
        {
            newClip = audioSources[Random.Range(0, audioSources.Length)];
            attempts--;
        }
        lastClip = newClip;
        return newClip;
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Limit") && !isHappy)
        {
            _playerCurrentHP._value--;
            ShakeScreen(camShakeAmount, camShakeLength);
        }
    }*/
    private void LimitCheck()
    {
        Collider2D collider = Physics2D.OverlapCircle(_limitChecker.position, _limitCheckerRadius, _limitMask);
        _isInLimit = collider != null;
    }

    private void ShakeScreen(float amt, float length)
    {
        _shakeAmount = amt;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", 0.1f);
    }

    private void BeginShake()
    {
        if(_shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;
            float offsetX = Random.value * _shakeAmount * 2 - _shakeAmount;
            float offsetY = Random.value * _shakeAmount * 2 - _shakeAmount;

            camPos.x += offsetX;
            camPos.y += offsetY;
            mainCam.transform.position = camPos;
        }
    }

   void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCam.transform.position = new Vector3(0,0,-10);
    }

    public void ChangeSprite()
    {
        _happyIndicator.sprite = _happySprite;
        isHappy = true;
    }


    #endregion

    //Les variables privées et protégées
    #region Private & Protected
    private bool _isInLimit = false;
    private bool isHappy = false;
    #endregion
}
