using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Combat : EnemyCombat
{
    public float dashSpeed;
    public float dashTime;
    public int shotsPerDash;
    public Projectile proj;
    private int timesShot;

    public override void attack(){
        shoot();
        if (timesShot == shotsPerDash){
            StartCoroutine(dash());
            StartCoroutine(movement.LockDirection(dashTime));
            timesShot = 0;
        }
        attackTimer = 0;
        canAttack = false;
    }

    private IEnumerator dash(){
        movement.movementSpeed += dashSpeed;
        movement.movementSpeed = -movement.movementSpeed;
        yield return new WaitForSeconds(dashTime);
        movement.movementSpeed = -movement.movementSpeed;
        movement.movementSpeed -= dashSpeed;
    }

    private void shoot(){
        Projectile newProj = Instantiate(proj, gameObject.transform.position, Quaternion.identity);
        newProj.direction = player.transform.position - gameObject.transform.position;
        // newProj.SetDirection(player.transform.position - gameObject.transform.position);
        timesShot++;
    }

    protected override void Start(){
        base.Start();
        timesShot = 0;
    }
    void Update(){
        Vector3 playerPos = player.transform.position;
        Vector3 currPos = gameObject.transform.position;
        Vector3 posDiff = playerPos - currPos;
        if (Mathf.Abs(posDiff.magnitude) < movement.targetDistance && canAttack){
            attack();
        }

        if (attackTimer > attackDelay){
            canAttack = true;
        }
        else{
            attackTimer += Time.deltaTime;
        }
    }
}
