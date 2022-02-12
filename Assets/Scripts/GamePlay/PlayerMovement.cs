using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private CharacterController playerController;
	private Vector3 direction;

	private void Awake()
	{
		playerController = GetComponent<CharacterController>();
	}

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        {
            // Debug.Log("Horizontal: " + floatingJoystick.Horizontal);
            // var camPos = cam.transform.forward;
            // camPos.y = 0;
            // direction = ( floatingJoystick.Horizontal *cam.transform.right) +
            //             (  floatingJoystick.Vertical *camPos);
    	     direction = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
            // direction = direction.normalized;
            
            // direction.x = direction.x * Input.GetAxis("Horizontal");
            // direction.z = direction.z * Input.GetAxis("Vertical");
            direction = direction.normalized;
            // direction.y = 0;
       
        }
    
        private void FixedUpdate()
        {
    	    Move();
        }
    
        private void Move()
        {
    	    playerController.Move(direction);
    	    // var speedVector = direction * movementSpeed;
    	    // rb.velocity = Vector3.Lerp(rb.velocity, speedVector, Time.fixedDeltaTime * damping);
    	    // transform.forward = Vector3.Lerp(transform.forward, direction.normalized, Time.fixedDeltaTime * turnSpeed);
    	    // animationVelocity = rb.velocity.magnitude;
    	    // animationVelocity = Mathf.Lerp(animationVelocity, 20f, Time.fixedDeltaTime * animationDamping);
    	    // animationController.SetSpeed(animationVelocity);
    	    // if(animationVelocity > 2.1 && animationController.isWaving)
    	    // 	animationController.Wave(false);
        }
}
