using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int vitality = 100;

    Rigidbody playerRigidbody;
    private Animator playerAnim;

    public float degrees;
    public float velocidad;
    private GameObject enemy;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        enemy = GameObject.Find("Enemigo");
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        ForwardMovement();
        MovSide();
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
        if (collision.gameObject.CompareTag("Enemigo") && boolValue)
        {

            EnemyControl enemyControl = collision.gameObject.GetComponent<EnemyControl>();
            if (enemyControl != null)
            {
                enemyControl.ReduceVitality(10); // Reduce la vitalidad del enemigo
                
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
