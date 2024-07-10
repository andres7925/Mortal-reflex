using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public Inventario inventario;
    public int cantidadDeVitalidad = 10;
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
        inventario.Cantidad = inventario.Cantidad + 1;
        Destroy(gameObject);
        }
        
    }
}
