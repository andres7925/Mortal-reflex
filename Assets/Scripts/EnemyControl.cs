using System.Collections;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 3.0f;
    public float vitality = 100f;

    private Animator enemyAnim;
    private Rigidbody enemyRb;
    private GameObject player;
    private PlayerControl playerControl;

    private float lastDamageTime;
    private bool muerto = false;
    private bool isColliding = false;
    private bool confirmacion = true;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyAnim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        playerControl = player.GetComponent<PlayerControl>();
        lastDamageTime = -10f;
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        
        if (vitality <= 0 && !muerto)
        {
            enemyAnim.SetBool("Die", true);
            muerto = true;
            if (confirmacion)
            {
                playerControl.enemigosAsesinados += 1;
                confirmacion = false;
            }

            // Autodestrucción después de 10 segundos (para que se ejecute la animacion de muerte)
            StartCoroutine(DestruirDespuesDe(10f));
        }

        if (!muerto && !isColliding)
        {
            // Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            // Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            enemyRb.MovePosition(transform.position + lookDirection * speed * Time.deltaTime);
            enemyAnim.SetBool("Move", true);
            //isColliding = false;
            enemyAnim.SetBool("Attack", false);
        }
        else
        {
            enemyAnim.SetBool("Move", false);
            enemyAnim.SetBool("Attack", true);
        }
        
        if (true){
            
        }
    }


    IEnumerator DestruirDespuesDe(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider collision)
    {
        bool boolValue = enemyAnim.GetBool("Attack");
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = true;
            if (boolValue && !muerto)
            {
                PlayerControl playerControl = collision.gameObject.GetComponent<PlayerControl>();
                if (playerControl != null && boolValue)
                {
                    if (Time.time - lastDamageTime >= 1.5f)
                    {
                        playerControl.vitality -= 8;
                        lastDamageTime = Time.time;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
