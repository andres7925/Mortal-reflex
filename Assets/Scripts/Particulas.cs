using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    public Vector3 incrementoDeTamaño = new Vector3(1, 1, 1); // Incremento de tamaño del jugador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Particula"))
        {

            // Destruir el objeto con el que colisionó
            Destroy(other.gameObject);

            // Aumentar el tamaño del jugador
            AumentarTamañoJugador();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Particula"))
        {
            // Destruir el objeto con el que colisionó
            Destroy(collision.gameObject);

            // Aumentar el tamaño del jugador
            AumentarTamañoJugador();
        }
    }

    private void AumentarTamañoJugador()
    {
        transform.localScale += incrementoDeTamaño;
        Debug.Log("Tamaño del jugador aumentado a: " + transform.localScale);
    }
}