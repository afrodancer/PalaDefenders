using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public float xSpeed;
    public float xIncr;
    public float xMaxSpeed;
    public float jumpSpeed;
    public float gravity;
    private Vector3 moveVector;

    void Start()
    {
        //enables reading input from player
        controller = GetComponent<CharacterController>();
        xSpeed = 0f;
        xIncr = 1.1f;
        xMaxSpeed = 7.5f;
        jumpSpeed = 2.5f;
        gravity = -18f;
        moveVector = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //x-axis=red/transform.right, y-axis=green/transform.up, z-axis=blue/transform.forward

    }
}
