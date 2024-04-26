using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float minMoveSpeed = 4.0f;
    public float maxMoveSpeed = 6.0f;
    private float moveSpeed;
    private Vector3 initialPosition;

    

    void Start()
    {
        // Generate a random move speed within the specified range
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        // Store the initial position of the obstacle
        initialPosition = transform.position;
    }

    void Update()
    {
        // Move the obstacle backwards with the randomly generated move speed
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Obstacle collidedObstacle = collision.gameObject.GetComponent<Obstacle>();
        if (collidedObstacle != null)
        {
            if (moveSpeed > collidedObstacle.moveSpeed)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        // Check if the collided object has the tag "agent" or "Finish"
        if (collision.gameObject.CompareTag("agent") || collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
