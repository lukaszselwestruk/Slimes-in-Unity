using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;


    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;

        private PlayerActions _playerActions;
        private Vector2 _movement;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _playerActions = new PlayerActions();
            _rb = GetComponent<Rigidbody2D>();
        }
        // new input system requires this method.
        private void OnEnable()
        {
            _playerActions.Enable();
        }

        private void PlayerInput()
        {
            _movement = _playerActions.Movement.Move.ReadValue<Vector2>();
        }

        private void Move()
        {
            _rb.MovePosition(_rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
        }
        private void Update()
        {
            PlayerInput();
        }

        private void FixedUpdate() 
        {
            Move();
        }
    }


