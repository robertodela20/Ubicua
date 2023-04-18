using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class farola : MonoBehaviour
{
    public Text Textfield;

    public void SetText(int id){
        //Textfield.text=text;
        Textfield.text="Farola apagada";
        /*string path = @"C:\Users\34628\Documents\Ubicua\iCampus\Assets\Scripts\texto_botons.txt";
        FileStream arquivo= File.Open(path,  FileMode.Open, FileAccess.Read);
        IEnumerable<string> linhas= File.ReadLines(path);
        List<string> lista_linhas= linhas.ToList();
        Textfield.text= lista_linhas[id];
        */

    }
}

