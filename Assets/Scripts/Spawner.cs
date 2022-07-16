using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private GameObject _sadGuyPrefab;

    //[SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private float delayAndSpawnRate = 2;
    [SerializeField] private float timeUntilSpawnRateIncrease = 30;

    #endregion

    #region Unity Lifecycle

    void Awake()
    {

    }

    void Start()
    {
        StartCoroutine(SpawnObject(delayAndSpawnRate));
        //SetTimeToSpawn();
    }

    void Update()
    {
        /*
        if (Time.time >= _nextTimeToSpawn)
        {
            SpawnSadGuy();
            SetTimeToSpawn();
        }
        */
    }
    #endregion

    #region Main Methods

    IEnumerator SpawnObject(float firstDelay)
    {
        float spawnRateCountdown = timeUntilSpawnRateIncrease;
        float spawnCountdown = firstDelay;
        while (true)
        {
            yield return null;
            spawnRateCountdown -= Time.deltaTime;
            spawnCountdown -= Time.deltaTime;

            // Should a new object be spawned?
            if (spawnCountdown < 0)
            {
                spawnCountdown += delayAndSpawnRate;
                Instantiate(_sadGuyPrefab, transform.position, Quaternion.identity);
            }

            // Should the spawn rate increase?
            if (spawnRateCountdown < 0 && delayAndSpawnRate > 1)
            {
                spawnRateCountdown += timeUntilSpawnRateIncrease;
                delayAndSpawnRate -= 0.1f;
            }
        }
    }


    /*
    private void SpawnSadGuy()
    {
        Instantiate(_sadGuyPrefab, transform.position, Quaternion.identity);
    }

    private void SetTimeToSpawn()
    {
        _nextTimeToSpawn = Time.time + _spawnInterval;
    }

    */



    #endregion

    #region Privates & Protected
    #endregion

}