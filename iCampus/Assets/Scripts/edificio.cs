using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class edificio : MonoBehaviour
{
    public Text Textfield;

    public void SetText(int id){
		string path = Directory.GetCurrentDirectory()+"/Assets/Scripts/texto_botons.txt";
        //string path = @"C:/Users/rober/OneDrive/Escritorio/informatica/4/ubicua/Ubicua/iCampus/Assets/Scripts/texto_botons.txt";
        IEnumerable<string> linhas= File.ReadLines(path);
        List<string> lista_linhas= linhas.ToList();
        Textfield.text= lista_linhas[id];
    }
}

