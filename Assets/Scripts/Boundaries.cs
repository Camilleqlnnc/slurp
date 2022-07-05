using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    #region Exposed
    [SerializeField] private Camera MainCamera;
    #endregion

    #region Unity Lifecycle
    void Start()
    {
        _screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 3;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 3;
    }

    void LateUpdate()
    {
        //BoundPlayer();

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _screenBounds.x * -1 + objectWidth, _screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, _screenBounds.y * -1 + objectHeight, _screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
    #endregion

    #region Main Methods

    #endregion

    #region Privates & Protected
    private Vector2 _screenBounds;
    private float objectWidth;
    private float objectHeight;
    #endregion
}
