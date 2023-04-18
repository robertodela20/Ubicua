using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;

public class farola : MonoBehaviour
{
    public Text Textfield;

    public void SetText(string arg){
		string path = Directory.GetCurrentDirectory()+"/Assets/Scripts/texto_botons.txt";
        IEnumerable<string> linhas= File.ReadLines(path);
        List<string> lista_linhas= linhas.ToList();
		char delimitador ='|';
		char delimitador2 =',';
		string[] id= arg.Split(delimitador2);
		int id1 = Int32.Parse(id[0]);
		int id2 = Int32.Parse(id[1]);
		string[] aux = lista_linhas[id1].Split(delimitador);
		if(id2==0){
			Textfield.text= aux[0];
		}
		else{
			Textfield.text= aux[1];
		}
		
        //Textfield.text= lista_linhas[id1];
        

    }
}

