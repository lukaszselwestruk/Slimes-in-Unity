using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;


    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;

        private PlayerActions playerActions;
        private Vector2 movement;
        private Rigidbody2D rb;
        private Animator myAnimator;
        private SpriteRenderer mySpriteRenderer;

        private void Awake()
        {
            playerActions = new PlayerActions();
            rb = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
            mySpriteRenderer = GetComponent<SpriteRenderer>();
        }
        // new input system requires this method.
        private void OnEnable()
        {
            playerActions.Enable();
        }

        private void PlayerInput()
        {
            movement = playerActions.Movement.Move.ReadValue<Vector2>();
            myAnimator.SetFloat("moveX", movement.x);
            myAnimator.SetFloat("moveY", movement.y);
        }

        private void Move()
        {
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
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
            if (mousePos.x < playerScreenPoint.x) mySpriteRenderer.flipX = true;
            else mySpriteRenderer.flipX = false;

        }
    }


