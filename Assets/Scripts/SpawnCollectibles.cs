﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectibles : MonoBehaviour
{
    // Start is called before the first frame update
    public float alcoholSpawnDelay = 0.3f;
    public float waterSpawnDelay = 1.1f;
    public GameObject alcohol;
    public GameObject waterBottle;
    void Start()
    {
        CustomGameManager.Instance.isPaused = false;
        SpawnBottles();
    }
    void Update()
    {
        if (CustomGameManager.Instance.isPaused == true)
        {
            var alcoholClones = GameObject.FindGameObjectsWithTag("Alcohol");
            foreach (var clone in alcoholClones)
            {
                Destroy(clone);
            }
            var waterClones = GameObject.FindGameObjectsWithTag("WaterBottle");
            foreach (var clone in waterClones)
            {
                Destroy(clone);
            }
            var brokenClones = GameObject.FindGameObjectsWithTag("BrokenCollectibles");
            foreach (var clone in brokenClones)
            {
                Destroy(clone);
            }
        }

    }
    IEnumerator SpawnAlcoholWithDelay()
    {
        while (CustomGameManager.Instance.isPaused == false)
        {
            float SpawnTimeDifference = Random.Range(1 * alcoholSpawnDelay, 3 * alcoholSpawnDelay);

            yield return new WaitForSecondsRealtime(SpawnTimeDifference);
            SpawnAlcohol();

        }
    }
    IEnumerator SpawnWaterlWithDelay()
    {
        while (CustomGameManager.Instance.isPaused == false)
        {
            float SpawnTimeDifference = Random.Range(1 * waterSpawnDelay, 3 * waterSpawnDelay);

            yield return new WaitForSecondsRealtime(SpawnTimeDifference);
            SpawnWaterBottle();

        }
    }
    void SpawnAlcohol()
    {
        Vector3 SpawnLocation = new Vector3(Random.Range(-5.8f, 5.8f), 5f, 0f);
        Instantiate(alcohol, SpawnLocation, Quaternion.identity);
    }
    void SpawnWaterBottle()
    {
        Vector3 SpawnLocation = new Vector3(Random.Range(-5.8f, 5.8f), 5f, 0f);
        Instantiate(waterBottle, SpawnLocation, Quaternion.identity);
    }
    public void SpawnBottles()
    {
        StartCoroutine(SpawnAlcoholWithDelay());
        StartCoroutine(SpawnWaterlWithDelay());
    }
}
