using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class JumpingAgentD : Agent
{
    public float jumpForce = 10f;
    public Transform reset = null;
    //public TextMesh score = null;
    public GameObject thrust = null;
    private Rigidbody rb = null;
    private float points = 0;
    
    public override void Initialize()
    {
        rb = this.GetComponent<Rigidbody>();
        ResetMyAgent();
    }
    public override void OnEpisodeBegin()
    {
        ResetMyAgent();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        // Use RayPerceptionSensor to detect obstacles
        sensor.AddObservation(RayPerception3D.Perceive(
            rayPerceptionSensor: rayPerceptionSensor,
            rayLength: rayLength,
            rayAngles: rayAngles,
            detectableObjects: obstacleLayer
        ));
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        // Perform actions based on the observations
        if (vectorAction[0] > 0.5f) // Example: if the agent's action vector indicates jumping
        {
            Jump();
        }

        // Add other actions as needed
    }

    void Jump()
    {
        // Apply jump force to the agent's Rigidbody
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetMyAgent()
    {
        this.transform.position = new Vector3(reset.position.x, reset.position.y, reset.position.z);
    }
}
