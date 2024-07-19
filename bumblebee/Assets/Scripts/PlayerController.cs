using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

     public VariableJoystick joy;



    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        //float xInput = Input.GetAxis("Horizontal");
        //float zInput = Input.GetAxis("Vertical");

        float xInput = joy.Horizontal;
        float zInput = joy.Vertical;

        float xSpeed = speed * xInput;
        float zSpeed = speed * zInput;

        Vector3 newVelocity = new Vector3(xSpeed, 0f,zSpeed);

        playerRigidbody.velocity = newVelocity; 
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.Endgame();
    }
}
