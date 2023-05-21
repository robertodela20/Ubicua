using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BusMove : MonoBehaviour
{
    /*[SerializeField] 
    Transform _FinalDestination;*/
    [SerializeField]
    int BusId;

    public Transform[] points;
    private int destPoint = 0;
    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.LogError("El componente navMeshAgent no está enlazado con " + gameObject.name);
        }
        else{
            agent.autoBraking = false;
            GotoNextPoint();
        }
    }


    // Select the next point in the rute
    private void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
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

    private void setPointsBus()
    {
        if(this.BusId == 0){
            
        }
    }



    // Choose the next destination point when the agent gets
    // close to the current one.
    void Update () {
        if (agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
