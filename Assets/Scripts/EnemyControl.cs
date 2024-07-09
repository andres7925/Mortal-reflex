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

    

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerControl = player.GetComponent<PlayerControl>();
        
        enemyAnim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

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
    }

    void OnCollisionStay(Collision collision)
    {
        bool boolValue = enemyAnim.GetBool("Attack");
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControl playerControl = collision.gameObject.GetComponent<PlayerControl>();
            if (playerControl != null)
            {
                playerControl.ReduceVitality(10); // Reduce la vitalidad del jugador
                ReduceVitality(10); // Reduce la vitalidad del enemigo
            }
        }
    }

    public void ReduceVitality(int amount)
    {
        vitality -= amount;
        Debug.Log("Enemy vitality: " + vitality);
        if (vitality <= 0)
        {
            //muerto
        }
    }
}
