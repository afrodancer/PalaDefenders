using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float fallSpeed;
    public LayerMask ground;
    public Transform feet;

    private Vector3 inputVector;
    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10.0f;
        jumpSpeed = 10.0f;
        fallSpeed = 0.1f;
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rbody.velocity.y, 0f);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0f, 0f));

        bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground, QueryTriggerInteraction.Ignore);
        if (Input.GetButtonDown("Jump") && isGrounded)
        { inputVector = new Vector3(rbody.velocity.x, jumpSpeed, 0f);}

        if (Input.GetButtonUp("Jump") && rbody.velocity.y > 0)
        { inputVector = new Vector3(rbody.velocity.x, rbody.velocity.y * 0.5f, 0f); }

        rbody.velocity = inputVector;
    }

}
