using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Combat : Enemy2Combat
{
    public float projectileSpread;
    public float timeBetweenShots;
    public float freezeTime;
    private Animator anim;

    protected override void Start()
    {
        base.Start();
        anim = gameObject.GetComponent<Animator>();
    }
    public override void attack(){
        StartCoroutine(ShootMultiple());
    }

    protected IEnumerator ShootMultiple(){
        for (int i=0; i < shotsPerDash; i++){
            shoot();
            anim.Play("normShoot");
            attackTimer = 0;
            canAttack = false;
            yield return new WaitForSeconds(timeBetweenShots);
        }

        StartCoroutine(dash());
        StartCoroutine(movement.LockDirection(dashTime));
        attackTimer = 0;
        canAttack = false;
    }

    protected IEnumerator freeze(){
        float oldSpeed = movement.movementSpeed;
        movement.movementSpeed = 0;
        yield return new WaitForSeconds(freezeTime);
        movement.movementSpeed = oldSpeed;
    }

    protected override IEnumerator dash()
    {
        StartCoroutine(base.dash());
        yield return new WaitForSeconds(dashTime);
        StartCoroutine(freeze());        
    }

    protected override void shoot()
    {
        Debug.Log("Shooting");
        base.shoot();
        Vector3 posDiff = player.transform.position - gameObject.transform.position;
        Projectile leftProj = Instantiate(proj, gameObject.transform.position, Quaternion.identity);
        Projectile rightProj = Instantiate(proj, gameObject.transform.position, Quaternion.identity);

        leftProj.direction = Quaternion.Euler(0, projectileSpread, 0) * posDiff;
        rightProj.direction = Quaternion.Euler(projectileSpread, 0, 0) * posDiff;
    }
}