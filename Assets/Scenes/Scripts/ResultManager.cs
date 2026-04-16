using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class ResultManager : MonoBehaviour
{
    [Header("BallSpawner")]
    public BallSpawner ballSpawner;

    [Header("Walls")]
    public Transform walls;

    [Header("Out Borders")]
    public Transform leftBorder;
    public Transform rightBorder;

    private List<float> wallX = new List<float>();

    private int[] slotCounts;

    public int ballCount;

    public bool isPrint = false;

    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < walls.childCount; i++)
        {
            wallX.Add(walls.GetChild(i).position.x);
        }

        wallX.Add(leftBorder.position.x);
        wallX.Add(rightBorder.position.x);
        wallX.Sort();

        slotCounts = new int[wallX.Count];
    }

    public int CalculateSlotIndex(float X)
    {

        for (int i = 0; i < wallX.Count -1; i++)
        {
            if (X > wallX[i] && X < wallX[i + 1])
            {
                return i;
            }
        }
        return -1;
    }

    public void SetDone(float X)
    {
        ballCount++;
        index = CalculateSlotIndex(X); 

        if (index != -1)
        {
            slotCounts[index]++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ballCount == ballSpawner.totalCount && isPrint == false)
        {
            for (int i = 0; i < slotCounts.Length - 1; i++)
            {
                Debug.Log($"슬롯 {i}: {slotCounts[i]}개");
            }

            isPrint = true;
        }
    }
}
