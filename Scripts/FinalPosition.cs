using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalPosition : MonoBehaviour
{
    public GameObject playerCar;
    public GameObject[] opponentCars;
    public TextMeshProUGUI resultText; // UI element to display the results
    public TextMeshProUGUI positionsText; // UI element to display car positions
    public Button restartButton; // Button to restart the game and go to the StartScene

    private void Start()
    {
        DisplayCarPositions();
        CheckWinner();
        restartButton.onClick.AddListener(RestartGame);
    }

    // Display the positions of each car
    private void DisplayCarPositions()
    {
        string[] carNames = new string[3] { "Player", "Car 1", "Car 2" };
        float[] carPositions = new float[3]
        {
            playerCar.transform.position.z,
            opponentCars[0].transform.position.z,
            opponentCars[1].transform.position.z
        };

        // Sort cars based on their positions (highest position first)
        for (int i = 0; i < carPositions.Length; i++)
        {
            for (int j = i + 1; j < carPositions.Length; j++)
            {
                if (carPositions[i] < carPositions[j])
                {
                    // Swap positions
                    float tempPos = carPositions[i];
                    carPositions[i] = carPositions[j];
                    carPositions[j] = tempPos;

                    // Swap car names as well
                    string tempName = carNames[i];
                    carNames[i] = carNames[j];
                    carNames[j] = tempName;
                }
            }
        }

        // Display the positions of each car
        positionsText.text = $"1st: {carNames[0]}\n2nd: {carNames[1]}\n3rd: {carNames[2]}";
    }

    // Check if the player won or lost and display the result
    private void CheckWinner()
    {
        float playerPosition = playerCar.transform.position.z;
        float opponent1Position = opponentCars[0].transform.position.z;
        float opponent2Position = opponentCars[1].transform.position.z;

        // Sort the cars based on positions to determine the rankings
        float[] carPositions = new float[3] { playerPosition, opponent1Position, opponent2Position };
        System.Array.Sort(carPositions);

        // Determine the player's ranking
        if (carPositions[2] == playerPosition) // First place
        {
            resultText.text = "You Win!";
        }
        else // Second or Third place
        {
            resultText.text = "You Lose!";
        }
    }

    // Restart the game and go to the StartScene
    private void RestartGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}
