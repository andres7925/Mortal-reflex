using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    public Vector3 incrementoDeTamaño = new Vector3(1, 1, 1); // Incremento de tamaño del jugador
    private PlayerControl PlayerControl; // Define playerControl a nivel de clase

    void Start()
    {
        PlayerControl = GetComponent<PlayerControl>(); // Asigna el componente a la variable de instancia

    }

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

        if (PlayerControl != null)
        {
            // Modifica la variable ataque en PlayerControl
            PlayerControl.ataque += 0.5f;
            
        }

    }
}
