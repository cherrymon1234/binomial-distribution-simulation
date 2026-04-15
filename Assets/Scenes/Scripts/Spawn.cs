using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject ballPrefab;

    [Header("Spawn Setting")]
    public int totalCount = 150;
    public float spawnInterval = 0.1f;

    [Header("Spawn Area")]
    public Vector2 spawnOffsetRange = new Vector2(3f, 8f);

    private List<GameObject> ballList = new List<GameObject>();

    bool isSpawning = false;

    public void StartSpawn()
    {
        foreach (GameObject ball in ballList)
        {
            if (ball != null)
            {
                Destroy(ball);
            }
        }

    ballList.Clear();

        if (isSpawning) return;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        isSpawning = true;

        for (int i = 0; i < totalCount; i++)
        {
            Vector2 offset = new Vector2(
                Random.Range(-spawnOffsetRange.x, spawnOffsetRange.x),
                spawnOffsetRange.y
            );

            GameObject ball = Instantiate(
                ballPrefab,
                (Vector2)transform.position + offset,
                Quaternion.identity
            );

            ballList.Add(ball);

            yield return new WaitForSeconds(spawnInterval);
        }

        isSpawning = false;
    }
}
