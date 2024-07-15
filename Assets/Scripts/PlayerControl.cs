using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
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

    public float gravityModifier;

    public bool muerto = false;
    public float ataque = 1;

    public int enemigosAsesinados = 0;

    public Inventario inventario;

    public TMP_Text CanvasTextEnemigos;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        enemy = GameObject.Find("Enemigo");
        playerAnim = GetComponent<Animator>();
        barraDevida.InicializarBarra(vitality);
        lastDamageTime = -10f;
        Physics.gravity *= gravityModifier;
        CanvasTextEnemigos.text = "Corazones " + enemigosAsesinados;
        inventario = inventario.GetComponent<Inventario>();
        
        
    }

    void Update()
    {
        CanvasTextEnemigos.text = "Clones " + enemigosAsesinados; 
        if (!muerto){
            bool boolValue = playerAnim.GetBool("Attack");
            if (!boolValue)
            {
                ForwardMovement();
            }
            
            MovSide();
            
        }

        if (enemigosAsesinados >= 5 && inventario.Cantidad == 10) 
        {
            SceneManager.LoadScene("Fin Del juego");
            
        }

        
        barraDevida.CambiarVidaActual(vitality);

        if (playerRigidbody.transform.position.y <= -10)
        {
            vitality = -5;
        }

        if (vitality <= 0)
        {
            playerAnim.SetBool("Die", true);
            muerto = true;
            Debug.Log("GAME OVER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    void OnTriggerStay(Collider collision){

        

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            
            bool boolValue = playerAnim.GetBool("Attack");
            if (collision.gameObject.CompareTag("Enemigo") && boolValue)
            {
                EnemyControl enemyControl = collision.gameObject.GetComponent<EnemyControl>();
                if (enemyControl != null)
                {
                    // Verifica si han pasado al menos 2 segundos desde la última reducción de vitalidad
                    if (Time.time - lastDamageTime >= 1.5f)
                    {
                        enemyControl.vitality -= 25 * ataque; // Reduce la vitalidad del enemigo
                        lastDamageTime = Time.time; // Actualiza el tiempo de la última reducción de vitalidad
                    }
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
