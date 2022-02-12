using System;
using System.Collections;
using System.Collections.Generic;
using _Main.Scripts.GamePlay;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Vector3 direction;
	public float movementSpeed;
	public float animationVelocity;
	public float damping;
	private PlayerAnimationController animationController;
	private Rigidbody rb;
	public float animationDamping;
	public float turnSpeed;

	private void Awake()
	{
		animationController= GetComponent<PlayerAnimationController>();
		rb = GetComponent<Rigidbody>();
	}


    // Update is called once per frame
    void Update()
        {
            // Debug.Log("direction: " + direction);
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
	        var speedVector = direction * movementSpeed;
            Debug.Log("direction: " + direction);
    	    rb.velocity = Vector3.Lerp(rb.velocity, speedVector, Time.fixedDeltaTime * damping);
    	    transform.forward = Vector3.Lerp(transform.forward, direction.normalized, Time.fixedDeltaTime * turnSpeed);
    	    animationVelocity = rb.velocity.magnitude;
    	    animationVelocity = Mathf.Lerp(animationVelocity, 20f, Time.fixedDeltaTime * animationDamping);
    	    animationController.SetSpeed(animationVelocity);
        }
}
