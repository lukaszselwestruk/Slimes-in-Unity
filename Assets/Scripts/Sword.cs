using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerActions playerActions;
    private Animator myAnimator;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
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
    private void Update()
    {
        mouseFollowWithOffset();
    }
    private void mouseFollowWithOffset()
    {
        var mousePos = Input.mousePosition;
        var playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;     
        
        if (mousePos.x < playerScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
