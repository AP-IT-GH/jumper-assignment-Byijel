using UnityEngine;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour
{
    // Singleton instance
    public static ObstacleManager Instance;

    // List to store spawned obstacles
    private List<GameObject> obstacles = new List<GameObject>();


    void Awake()
    {
        // Assign the singleton instance
        Instance = this;
    }

    // Add obstacle to the list
    public void AddObstacle(GameObject obstacle)
    {
        obstacles.Add(obstacle);
    }

    // Remove all obstacles from the scene
    public void RemoveObstacles()
    {
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle);
        }
        // Clear the list after removing obstacles
        obstacles.Clear();
    }
}
