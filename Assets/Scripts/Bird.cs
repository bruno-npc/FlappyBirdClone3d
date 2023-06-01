using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpPower = 0.5f;
    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        jumpCooldown -= Time.deltaTime;

        bool canJump = jumpCooldown <= 0 && !GameManager.Instance.isGameOver();
        if(canJump){
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput){
                jump();
            }       
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Obstacle")){
            GameManager.Instance.endGame();
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Pass")){
            GameManager.Instance.score++;
        }
    }

    private void jump(){
        jumpCooldown = jumpInterval;
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3 (0, jumpPower, 0), ForceMode.Impulse);
    }
}
