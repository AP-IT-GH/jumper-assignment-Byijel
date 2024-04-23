using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class JumpingAgent : Agent
{
    public float force = 15f;
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
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Assuming the first action is the one you're interested in
        float action = actionBuffers.ContinuousActions[0];

        if (action == 1)
        {
            UpForce();
            thrust.SetActive(true);
        }
        else
        {
            thrust.SetActive(false);
        }
    }
    public override void OnEpisodeBegin()
    {
        ResetMyAgent();
    }
/*    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;
        if (Input.GetKey(KeyCode.UpArrow) == true)
            actionsOut[0] = 1;
    }*/
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle") == true)
        {
            AddReward(-1.0f);          
            Destroy(collision.gameObject);
            EndEpisode();
        }
        if (collision.gameObject.CompareTag("walltop") == true)
        {
            AddReward(-0.9f);
            EndEpisode();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wallreward") == true)
        {
            AddReward(0.1f);
            points++;
            //score.text = points.ToString();
        }     
    }
    private void UpForce()
    {
        Debug.Log("Jumping with force: " + force);
        rb.AddForce(Vector3.up * force, ForceMode.Acceleration);
    }

    private void ResetMyAgent()
    {
        this.transform.position = new Vector3(reset.position.x, reset.position.y, reset.position.z);
    }
}
