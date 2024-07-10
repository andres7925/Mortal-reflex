using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hitSound;

    void Start()
    {
        // Asegúrate de que el AudioSource está asignado
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionó es el enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Reproduce el sonido de golpe
            audioSource.PlayOneShot(hitSound);
        }
    }
}
