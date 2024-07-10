using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Implementa aquí la lógica para cuando el objeto colisione con el jugador
        }
    }

    private void Start()
    {
        // Implementa aquí la lógica que necesites al iniciar el script
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
