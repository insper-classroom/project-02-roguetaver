using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToGoalAgent : Agent
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private Material winMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private GameObject door;
    [SerializeField] private bool doorIsOpen;

    public void Start()
    {
        initialPosition = this.transform.localPosition;
    }

    public override void OnEpisodeBegin(){
        transform.localPosition = initialPosition;
        transform.localEulerAngles = new Vector3(0f,180f,0f);
        doorIsOpen = false;
        door.SetActive(true);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        //float turn = actions.ContinuousActions[1];

        AddReward(-0.002f);

        Vector3 moveDir = new Vector3 (moveX,0,moveZ);
        transform.localPosition += moveDir * Time.deltaTime * moveSpeed;

        //transform.localPosition += transform.forward * move * Time.deltaTime * moveSpeed;
        //transform.localEulerAngles += new Vector3 (0,turn,0) * Time.deltaTime * turnSpeed;
        
    }

    public override void Heuristic(in ActionBuffers actionsOut){
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter(Collider other){
        if(other.TryGetComponent<DoorButton>(out DoorButton doorButton)){
            if(!doorIsOpen) {
                doorIsOpen = true;
                AddReward(1f);
            }
        }
        if(other.TryGetComponent<Exit>(out Exit exit)){
            AddReward(5f);
            floorMeshRenderer.material = winMaterial;
            EndEpisode();
        }
        if(other.TryGetComponent<Wall>(out Wall wall)){
            SetReward(-1f);
            floorMeshRenderer.material = loseMaterial;
            EndEpisode();
        }
        
    }
}