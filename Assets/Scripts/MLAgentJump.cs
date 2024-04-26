using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class JumpingAgentD : Agent
{
    public float jumpMultiplier = 1.5f;
    public Transform reset = null;
    private Rigidbody rb = null;
    public Transform obstacle = null;
    
    public override void Initialize()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    public override void OnEpisodeBegin()
    {
        Debug.Log("Reset");
        ResetMyAgent();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        // Movement
        int action = actions.DiscreteActions[0];

        if (action == 1 && IsGrounded())
        {
            Debug.Log("Jumped");
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Vector3 velocity = rigidbody.velocity;

            velocity.y += jumpMultiplier;
            rigidbody.velocity = velocity;
            AddReward(-1f);
        }
    }

    private void ResetMyAgent()
    {
        this.transform.position = new Vector3(reset.position.x, reset.position.y, reset.position.z);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }


    public bool IsGrounded()
    {
        Debug.Log("Touching ground");
        RaycastHit hit;
        float rayLength = 1f; // Adjust based on your character's size
        int groundLayerMask = 1 << LayerMask.NameToLayer("Ground");

        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength, groundLayerMask))
        {
            return true;
        }
        return false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("Hit obstacle");
            AddReward(-3f);
            EndEpisode();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wallReward"))
        {
            Debug.Log("Hit reward");
            AddReward(5f);
        }
    }
}
