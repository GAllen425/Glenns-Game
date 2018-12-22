using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 100f;
    private AudioSource audioSource;

    private bool jump = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if (jump)
        {
            jump = false;
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
	}

    private void Update()
    {

            if (Input.GetMouseButtonDown(0))
            {
                rb.useGravity = true;
                jump = true;
            }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            rb.AddForce (new Vector3(-200, 500,1000), ForceMode.Impulse);
            rb.detectCollisions = false;
            GameManager.instance.PlayerCollided();
        }
    }
}
