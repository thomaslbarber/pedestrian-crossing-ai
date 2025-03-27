using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class Pedestrian : Agent
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;

    Rigidbody rb;

    private Vector3 startPos = new Vector3(9f, 0.5f, 0f);


    int previousPos;
    int currentPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localPosition = new Vector3(Random.Range(startPos.x - 1f, startPos.x + 1f), startPos.y, Random.Range(startPos.z - 55f, startPos.z + 11f));
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(Random.Range(startPos.x - 1f, startPos.x + 1f), startPos.y, Random.Range(startPos.z - 55f, startPos.z + 11f));
        rb.velocity = Vector3.zero;
        //targetTransform.localPosition = new Vector3(Random.Range(-1f, 1f), -0.2656937f, Random.Range(-4f, -8f));

        //base.OnEpisodeBegin();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        if (transform.localPosition.x > transform.localPosition.x + moveX) { AddReward(0.1f); }
        else { AddReward(-0.1f); }

        float moveSpeed = 20f;
        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
        //base.OnActionReceived(actions);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        Debug.Log("Heuristic() called");
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = -Input.GetAxisRaw("Vertical");
        continuousActions[1] = Input.GetAxisRaw("Horizontal");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("goal"))
        {
            Debug.Log("hit goal");
            SetReward(+1000f);
            //floorMeshRenderer.material = winMaterial;
            transform.localPosition = new Vector3(Random.Range(startPos.x - 1f, startPos.x + 1f), startPos.y, Random.Range(startPos.z - 55f, startPos.z + 11f));
            rb.velocity = Vector3.zero;
        }
        else if (other.CompareTag("wall"))
        {
            Debug.Log("hit wall: " + other.gameObject.name);
            SetReward(-1000f);
            //floorMeshRenderer.material = loseMaterial;
            EndEpisode();
        }
        else if (other.CompareTag("car"))
        {
            Debug.Log("hit car");
            SetReward(-1000f);
            EndEpisode();
        }
    }
}
