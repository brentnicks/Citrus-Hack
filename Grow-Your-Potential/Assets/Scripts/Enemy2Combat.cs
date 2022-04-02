using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Combat : EnemyCombat
{
    public float leapDistance;

    public override void attack(){
        dash();
        attackTimer = 0;
        canAttack = false;
    }

    private void dash(){
        Debug.Log("Leaping");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 playerPos = player.transform.position;
        Vector2 direction = playerPos - gameObject.transform.position;
        rb.AddForce(direction.normalized * leapDistance);
    }
}
