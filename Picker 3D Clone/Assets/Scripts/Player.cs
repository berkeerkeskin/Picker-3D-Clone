using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidBody;
    
    [SerializeField] private float 
        sideMoveMultiplier,
        forwardSpeed,
        sideSpeed;

    private float _horizontalInput;
    void Awake()
    {
        ComponentInitialization();
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        GetInput();
        MoveSideways();
    }

    private void FixedUpdate()
    {
        MoveForward();
        
    }

    private void ComponentInitialization()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }    
    private void GetInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        //Debug.Log(_horizontalInput);
    }
    private void MoveForward()
    {
        Vector3 forwardMove = Vector3.forward * forwardSpeed * Time.deltaTime;
        //_rigidBody.MovePosition(_rigidBody.position + forwardMove);
        _rigidBody.MovePosition(_rigidBody.position + forwardMove);
    }

    private void MoveSideways()
    {
        if (_horizontalInput > 0)
        {
            Vector3 sidewaysMove = Vector3.right * sideSpeed * Time.fixedDeltaTime * sideMoveMultiplier;
            //_rigidBody.MovePosition(_rigidBody.position + sidewaysMove);
            _rigidBody.velocity = sidewaysMove;
        }else if (_horizontalInput < 0)
        {
            Vector3 sidewaysMove = Vector3.left * sideSpeed * Time.fixedDeltaTime * sideMoveMultiplier;
            //_rigidBody.MovePosition(_rigidBody.position + sidewaysMove);
            _rigidBody.velocity = sidewaysMove;
        }
    }
}
