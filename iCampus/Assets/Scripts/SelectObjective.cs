using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SelectObjective : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    SpriteRenderer sprite;
    public static List<SelectObjective> listaObjetivos = new List<SelectObjective>();
    private bool seleccionado = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        listaObjetivos.Add(this);
        agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && seleccionado){
            agent.SetDestination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void OnMouseDown() 
    {
        this.seleccionado = true;
        sprite.color = Color.green;
        foreach(SelectObjective obj in listaObjetivos) {
            if(obj != this){
                obj.seleccionado = false;
                obj.sprite.color = Color.white;
            }
        }

    }

}
