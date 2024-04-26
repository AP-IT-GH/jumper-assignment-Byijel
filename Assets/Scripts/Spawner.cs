using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab = null;
    public Transform spawn = null;
    public float minTime = 1.0f;
    public float maxTime = 3.0f;
    public float spawnInterval = 1.0f; // Interval between spawns

    private void Start()
    {
        // Start spawning obstacles immediately
        InvokeRepeating("SpawnObstacle", Random.Range(minTime, maxTime), spawnInterval);
    }

    private void SpawnObstacle()
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = spawn.position;
        // Add the spawned obstacle to a list
        ObstacleManager.Instance.AddObstacle(go);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "agent" or "Finish"
        if (other.CompareTag("agent") || other.CompareTag("Finish"))
        {
            // Remove all spawned obstacles
            ObstacleManager.Instance.RemoveObstacles();
        }
    }
}
