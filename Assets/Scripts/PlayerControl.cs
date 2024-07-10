using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int vitality;

    public int vidaMaxima = 100;

    [SerializeField] private BarraVida barraDevida;

    Rigidbody playerRigidbody;
    private Animator playerAnim;

    public float degrees;
    public float velocidad;
    private GameObject enemy;
    private float lastDamageTime;

    public bool muerto = false;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        enemy = GameObject.Find("Enemigo");
        playerAnim = GetComponent<Animator>();
        barraDevida.InicializarBarra(vitality);
        lastDamageTime = -10f;
        
        
    }

    void Update()
    {
        if (!muerto){
            ForwardMovement();
            MovSide();
        }

        //Debug.Log("Vitalidad Player" + vitality);
        barraDevida.CambiarVidaActual(vitality);

        if (vitality <= 0)
        {
            playerAnim.SetBool("Die", true);
            muerto = true;
        }  
    }

    void MovSide()
    {
        float MovementSide = Input.GetAxis("Horizontal");
        if (MovementSide != 0)
        {
            transform.Rotate(0, MovementSide * degrees, 0);
        }
        else
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
        }
    }

    void ForwardMovement()
    {
        float MovementForward = Input.GetAxis("Vertical");
        if (MovementForward != 0)
        {
            Vector3 movement = transform.forward * velocidad * MovementForward;
            playerRigidbody.MovePosition(transform.position + movement * Time.deltaTime);
        }
    }


    void OnCollisionStay(Collision collision)
    {
        bool boolValue = playerAnim.GetBool("Attack");
        if (collision.gameObject.CompareTag("Enemigo") && boolValue == true)
        {
            EnemyControl enemyControl = collision.gameObject.GetComponent<EnemyControl>();
            if (enemyControl != null)
            {
                // Verifica si han pasado al menos 2 segundos desde la última reducción de vitalidad
                if (Time.time - lastDamageTime >= 1.5f)
                {
                    enemyControl.vitality -= 15; // Reduce la vitalidad del enemigo
                    lastDamageTime = Time.time; // Actualiza el tiempo de la última reducción de vitalidad
                }
            }
        }
    }
    public void ReduceVitality(int amount)
    {
        vitality -= amount * Time.captureFramerate;
        Debug.Log("Player vitality: " + vitality);
        if (vitality <= 0)
        {
            
        }
    }
}
