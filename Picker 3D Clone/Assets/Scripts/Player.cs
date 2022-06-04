using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player MagnetPlayer { get; private set; }
    private Rigidbody _rigidBody;
    
    [SerializeField] private float 
        sideMoveMultiplier,
        forwardSpeed,
        sideSpeed;

    private float _horizontalInput;
    public bool isPlayerStopped = false;
    void Awake()
    {
        //Singleton Design Pattern
        if (MagnetPlayer == null)
        {
            MagnetPlayer = this;
            DontDestroyOnLoad(gameObject);
        }
        ComponentInitialization();
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
    }
    private void MoveForward()
    {
        if (!isPlayerStopped)
        {
            Vector3 forwardMove = Vector3.forward * forwardSpeed;
            //_rigidBody.MovePosition(_rigidBody.position + forwardMove);
            _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0f, forwardSpeed);
        }
        else
        {
            _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0f, 0f);
        }
    }

    private void MoveSideways()
    {
        if (_horizontalInput > 0)
        {
            Vector3 sidewaysMove = Vector3.right * sideSpeed;
            //_rigidBody.MovePosition(_rigidBody.position + sidewaysMove);
            _rigidBody.velocity = new Vector3(sideSpeed, 0f, _rigidBody.velocity.z);
        }else if (_horizontalInput < 0)
        {
            Vector3 sidewaysMove = Vector3.left * sideSpeed;
            //_rigidBody.MovePosition(_rigidBody.position + sidewaysMove);
            _rigidBody.velocity = new Vector3(-sideSpeed, 0f, _rigidBody.velocity.z);
        }
        else
        {
            _rigidBody.velocity = Vector3.zero;
        }
    }
}
