using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 3.0f;
    public int vitality = 100;

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
            enemyRb.MovePosition(transform.position + lookDirection * speed * Time.deltaTime);
            enemyAnim.SetBool("Move", true);
        }
        else
        {
            enemyAnim.SetBool("Move", false);
            enemyAnim.SetBool("Attack", true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
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
