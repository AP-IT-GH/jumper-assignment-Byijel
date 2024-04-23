using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class JumpingAgent : Agent
{
    public float jumpForce = 10f;
    public float raycastDistance = 2f;
    public LayerMask obstacleLayer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        // Reset agent's position and velocity
        rb.velocity = Vector3.zero;
        transform.localPosition = new Vector3(0, 1, 0); // Adjust starting position as needed
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // No observations needed in this basic example
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        // Apply forward force based on the input
        float forwardForce = Mathf.Clamp(actions.ContinuousActions[0], -1f, 1f);
        rb.AddForce(transform.forward * forwardForce * 10f);

        // If an obstacle is detected in front, jump
        if (Physics.Raycast(transform.position, transform.forward, raycastDistance, obstacleLayer))
        {
            Jump();
        }

        // Penalty for time steps to encourage the agent to complete the task quickly
        AddReward(-0.05f);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish")) // Assuming a "Finish" tag for the goal
        {
            SetReward(1f);
            EndEpisode();
        }
    }
}
