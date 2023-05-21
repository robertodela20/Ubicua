using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BusMove : MonoBehaviour
{
    //Public variables
    /*[SerializeField] 
    Transform _FinalDestination;*/
    public int BusId;

    [SerializeField]
    Transform[] points;

    //[SerializeField]
    //float totalWaitTime = 3f;
    
    //private variables
    NavMeshAgent _navMeshAgent;
    int destPoint;
    bool _travelling;
    //bool _waiting;
    //float _waitTimer;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.LogError("El componente navMeshAgent no está enlazado con " + gameObject.name);
        }
        else{
            if (points.Length > 0){
                _navMeshAgent.autoBraking = false;
                _navMeshAgent.updateRotation = false;
		        _navMeshAgent.updateUpAxis = false;
                GotoNextPoint();
            }
        }
    }


    // Select the next point in the rute
    private void GotoNextPoint() {
        // Set the agent to go to the currently selected destination.
        Vector3 targetDestination = points[destPoint].transform.position;
        _navMeshAgent.SetDestination(targetDestination);
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
        _travelling = true;
    }

    /* Set the final destination target
    private void SetDestination()
    {
        if(_FinalDestination != null)
        {
            Vector3 targetVector = _FinalDestination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }*/

    /*private void setPointsBus()
    {
        if(this.BusId == 0){

        }
    }*/

    // Choose the next destination point when the agent gets
    // close to the current one.
    void Update () {
        if (_travelling && (_navMeshAgent.remainingDistance <= 7.0f) && !_navMeshAgent.pathPending){
            _travelling = false;
            Debug.Log(_navMeshAgent.remainingDistance);
            //Wait in busStop
            /*if(_navMeshAgent.){

            }*/

            GotoNextPoint();
        }
    }
}
