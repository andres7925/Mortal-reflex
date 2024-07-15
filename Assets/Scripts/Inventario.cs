using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Inventario : MonoBehaviour
{
    public int Cantidad = 0;
    public TMP_Text CanvasText;

    void Start(){
        CanvasText.text = "Corazones " + Cantidad;
    }

    void Update(){
        
        CanvasText.text = "Corazones " + Cantidad;
    }
}