using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    public GameObject effect;

    public AudioClip sound1;
    public AudioClip sound2;

    public AudioSource audio;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 5f);

    }



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                audio.PlayOneShot(sound1);

                Instantiate(effect, transform.position, Quaternion.identity);
                playerController.Die();
            }
        }
    }
}
