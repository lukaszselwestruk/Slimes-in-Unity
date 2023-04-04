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
        private Animator _myAnimator;
        private SpriteRenderer _mySpriteRenderer;

        private void Awake()
        {
            _playerActions = new PlayerActions();
            _rb = GetComponent<Rigidbody2D>();
            _myAnimator = GetComponent<Animator>();
            _mySpriteRenderer = GetComponent<SpriteRenderer>();
        }
        // new input system requires this method.
        private void OnEnable()
        {
            _playerActions.Enable();
        }

        private void PlayerInput()
        {
            _movement = _playerActions.Movement.Move.ReadValue<Vector2>();
            _myAnimator.SetFloat("moveX", _movement.x);
            _myAnimator.SetFloat("moveY", _movement.y);
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
            SetPlayerFacingDirection();
            Move();
        }

        private void SetPlayerFacingDirection()
        {
            var mousePos = Input.mousePosition;
            var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
            if (mousePos.x < playerScreenPoint.x) _mySpriteRenderer.flipX = true;
            else _mySpriteRenderer.flipX = false;

        }
    }


