using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rigidbody;
    public Animator animFarmer;
    private Vector2 moveDirection;


    // Update is called once per frame
    void Update()
    {
        ///Processing Inputs
        ProcessInputs();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehavior is enabled.
    /// </summary>

    void FixedUpdate()
    {
        ///Physcics Calculations
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    /// <summary>
    /// Callback for processing animation movements for modifying root motion.
    /// </summary>

    void Move()
    {
        rigidbody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        //Animation here
        animFarmer.SetFloat("SpeedX", moveDirection.x);
        animFarmer.SetFloat("SpeedY", moveDirection.y);


    }
}
