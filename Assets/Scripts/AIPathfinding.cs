using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AIPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDirection = targetPosition;
    }
}
