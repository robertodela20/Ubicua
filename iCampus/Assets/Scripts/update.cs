using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class update : MonoBehaviour
{
	int hora;
	int reloj;
	//public Text Textfield;
    // Start is called before the first frame update
    void Start()
    {
		hora=0;
		reloj=0;
        
    }

    // Update is called once per frame
    void Update()
    {
		if(reloj<30000){
			reloj++;
		}
		else{
			reloj=0;
			hora++;
			if(hora>24){
				hora=0;
			}
		}
		
        
    }
}
