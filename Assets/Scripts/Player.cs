using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;


    [SerializeField] private float velocityHorizontal = 2;
    [SerializeField] private float velocityVertical = 5;
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;


    [SerializeField] private int buget;

    private void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // JUMP
        if (Input.GetKeyDown(KeyCode.Space)) jumpKeyWasPressed = true;
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput * velocityHorizontal, rigidbodyComponent.velocity.y, rigidbodyComponent.velocity.z);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0) return;

        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * velocityVertical, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9 )
        {
            CollectCoin(other.gameObject);
        }
    }

    private void CollectCoin(UnityEngine.GameObject coinObject)
    {

        Coin coin = coinObject.GetComponent<Coin>();

        Debug.Log($"CollectCoin: Player collect {coin.value} golds. ");
        buget += coin.value;
        Debug.Log($"Now the buget of Player is {buget} golds. ");

        Destroy(coinObject);
    }

}
