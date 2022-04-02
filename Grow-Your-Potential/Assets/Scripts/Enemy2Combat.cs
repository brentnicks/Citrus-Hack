using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Combat : EnemyCombat
{
    public float dashSpeed;
    public float dashTime;

    public override void attack(){
        StartCoroutine(dash());
        // StartCoroutine(movement.LockDirection(dashSpeed));
        attackTimer = 0;
        canAttack = false;
    }

    private IEnumerator dash(){
        movement.movementSpeed += dashSpeed;
        yield return new WaitForSeconds(dashTime);
        movement.movementSpeed -= dashSpeed;
    }
}
