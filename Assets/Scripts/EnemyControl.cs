using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 3.0f;
    public int vitality = 100;

    private Animator EnemigoAnim;
    private Rigidbody enemyRb;
    private GameObject player;
    private PlayerControl playerControl;
    private Animator enemyAnim;

    private float lastDamageTime;

    private bool muerto = false;

    

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerControl = player.GetComponent<PlayerControl>();
        
        enemyAnim = GetComponent<Animator>();
        lastDamageTime = -10f;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log("vitalidad" + vitality);

        if (vitality <= 0)
        {
            enemyAnim.SetBool("Die", true);
            muerto = true;
        }  

        if (!muerto){
        if (distance > 1)
        {
            enemyAnim.SetBool("Attack", false);
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            // Rotar hacia el jugador
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);

            enemyRb.MovePosition(transform.position + lookDirection * speed * Time.deltaTime);
            enemyAnim.SetBool("Move", true);
        }
        else
        {
            enemyAnim.SetBool("Move", false);
            enemyAnim.SetBool("Attack", true);
        }

        if (vitality <= 0)
        {
            enemyAnim.SetBool("Die", true);
        }  

        }



    }

    void OnCollisionStay(Collision collision)
    {
        bool boolValue = enemyAnim.GetBool("Attack");
        if (collision.gameObject.CompareTag("Player") && boolValue == true)
        {
            PlayerControl playerControl = collision.gameObject.GetComponent<PlayerControl>();
            if (playerControl != null && boolValue == true)
            {
                if (Time.time - lastDamageTime >= 1.5f)
                {
                    playerControl.vitality -= 10; // Reduce la vitalidad del jugador
                    //Debug.Log("Player vitality: " + playerControl.vitality);
                    lastDamageTime = Time.time;
                }

            }
        }
    }

    public void ReduceVitality(int amount)
    {
        vitality -= amount * Time.captureFramerate;
        Debug.Log("Enemy vitality: " + vitality);
        if (vitality <= 0)
        {
            //muerto
        }
    }
}
