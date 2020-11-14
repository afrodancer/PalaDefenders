using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerController : MonoBehaviour
{
	Rigidbody rbody;
	public LayerMask ground;
	public Transform feet;

	private float jumpHeight;
	private Vector3 direction;
	private float moveSpeed;
	private float maxSpeed;
	private float threshold;
	private float decelerate;
	private float doubleJump;
	private float maxJumps;
	
	// Start is called before the first frame update
	void Start()
	{
		rbody = GetComponent<Rigidbody>();
		jumpHeight = 3f;
		maxJumps = 1f;
		moveSpeed = 8f;
		maxSpeed = 10f;
		threshold = 0.05f;
		direction = Vector3.zero;
		decelerate = -0.4f;
		doubleJump = 0f;
	}

	// Update is called once per frame
	void Update()
	{
        bool isGrounded()
        {
            if (Physics.CheckSphere(feet.position, 0.1f, ground))
            {
                doubleJump = 0;
                return true;
            }
            else
                return false;
        }

        if (Input.GetButtonDown("Jump") && (isGrounded() || doubleJump < maxJumps))
        {
            doubleJump += 1;
            rbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
			//BUG: jumping causes player to start accelerating backwards
        }

        if (Input.GetButton("Horizontal"))
        {
			direction.x = Input.GetAxis("Horizontal");
			direction = direction.normalized;
			if (direction != Vector3.zero)
			{
				transform.forward = direction;
				if (rbody.velocity.magnitude > maxSpeed)
				{ return; }
				else
				{
					rbody.AddForce(direction * moveSpeed, ForceMode.Acceleration); 
				}
			}
        }
        else
        {
            if (rbody.velocity.magnitude > threshold)
            {
				rbody.AddForce(direction * rbody.velocity.magnitude * decelerate, ForceMode.Acceleration);
			}
        }

    }
}
