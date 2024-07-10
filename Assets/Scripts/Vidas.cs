using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    private GameObject player;
    private PlayerControl playerControl;

    private void Start()
    {
        // Encuentra el objeto con la etiqueta "Player" y obtiene el componente PlayerControl
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);  // Destruye el objeto 'corazon'
            playerControl.vitality += 10;  // Incrementa la vitalidad del jugador en 10
        }
    }
}
