using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;
    public Checkpoint[] checkpoints;

    public int TotalCheckpoints => checkpoints.Length;

    private void Awake()
    {
        if (Instance == null) Instance = this;

     
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].index = i;
        }
    }
}
