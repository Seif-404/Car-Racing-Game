using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapManager : MonoBehaviour
{
    public int totalLaps = 2; // Total laps for the race
    public TextMeshProUGUI lapText; // UI element for displaying lap info

    private int currentLap = 0; // Current lap number
    private int nextCheckpointIndex = 0; // Index of the next checkpoint to hit

    public string gameSceneName = "Final";
    private void Start()
    {
        UpdateLapText(); // Initialize the lap text
    }

    private void OnTriggerEnter(Collider other)
    {
        // Handle checkpoint collisions
        if (other.CompareTag("CheckPoint"))
        {
            Checkpoint checkpoint = other.GetComponent<Checkpoint>();
            if (checkpoint != null && checkpoint.index == nextCheckpointIndex)
            {
                // Advance to the next checkpoint
                nextCheckpointIndex++;

                // If all checkpoints are completed, the player should loop back to the startline
                if (nextCheckpointIndex >= CheckpointManager.Instance.TotalCheckpoints)
                {
                    nextCheckpointIndex = 0; // Reset checkpoint index
                }
            }
        }

        // Handle crossing the startline
        if (other.CompareTag("StartLine") && nextCheckpointIndex == 0)
        {
            currentLap++; // Increment the lap
            UpdateLapText(); // Update the UI

            // End the race if the player completes all laps
            if (currentLap >= totalLaps)
            {
                Debug.Log("Race Finished!");
                SceneManager.LoadScene(gameSceneName);
                // Add logic to handle race completion, e.g., stop player movement
            }
        }
    }

    private void UpdateLapText()
    {
        lapText.text = $"Lap {currentLap}/{totalLaps}";
    }

}
