using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public GameObject playerCar;  
    public GameObject[] opponentCars; 
    public TextMeshProUGUI placementText;  

    private string[] previousRankings = new string[3]; 

    private void Update()
    {
        
        string[] currentRankings = GetCarPlacements();

        
        Debug.Log($"Player Position: {playerCar.transform.position.z}");
        Debug.Log($"Car 1 Position: {opponentCars[0].transform.position.z}");
        Debug.Log($"Car 2 Position: {opponentCars[1].transform.position.z}");
        Debug.Log($"Current Rankings: {string.Join(", ", currentRankings)}");

        
        if (!AreRankingsEqual(currentRankings, previousRankings))
        {
           
            placementText.text = $"1st: {currentRankings[0]}\n2nd: {currentRankings[1]}\n3rd: {currentRankings[2]}";

            previousRankings = (string[])currentRankings.Clone(); 
        }
    }

    private string[] GetCarPlacements()
    {
       
        float playerPosition = playerCar.transform.position.z;
        float opponent1Position = opponentCars[0].transform.position.z;
        float opponent2Position = opponentCars[1].transform.position.z;

      
        float[] carPositions = new float[3] { playerPosition, opponent1Position, opponent2Position };
        string[] carNames = new string[3] { "Player", "Car 1", "Car 2" };

        Car[] cars = new Car[3]
        {
            new Car("Player", playerPosition),
            new Car("Car 1", opponent1Position),
            new Car("Car 2", opponent2Position)
        };

       
        System.Array.Sort(cars, (a, b) => b.position.CompareTo(a.position)); 
        
        string[] rankings = new string[3];

       
        for (int i = 0; i < 3; i++)
        {
            rankings[i] = cars[i].name;
        }

        return rankings;
    }

    
    private bool AreRankingsEqual(string[] array1, string[] array2)
    {
        if (array1.Length != array2.Length)
            return false;

        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
                return false;
        }

        return true;
    }

    private class Car
    {
        public string name;
        public float position;

        public Car(string name, float position)
        {
            this.name = name;
            this.position = position;
        }
    }

}
