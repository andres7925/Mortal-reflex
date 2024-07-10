using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{

    private void OnCollisionEnter(Collision other) // Cambié Collider a Collision
    {
        if (other.gameObject.tag == "Player")
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

        {
            Destroy(gameObject);
        }
    }
}
