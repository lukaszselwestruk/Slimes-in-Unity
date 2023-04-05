using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerActions playerActions;
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        playerActions = new PlayerActions();
    }
    private void OnEnable()
    {
        playerActions.Enable();
    }
    // dont want to passing through anything, so use "_"
    private void Start()
    {
        playerActions.Combat.Attack.started += _ => Attack();
    }

    private void Attack()
    {
        myAnimator.SetTrigger("Attack");
    }
}
