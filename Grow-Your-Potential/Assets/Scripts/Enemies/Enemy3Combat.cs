using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Combat : Enemy2Combat
{
    public float projectileSpread;
    protected override void shoot()
    {
        base.shoot();
        Projectile leftProj = Instantiate(proj, gameObject.transform.position, Quaternion.identity);
        leftProj.direction = player.transform.position - gameObject.transform.position;
    }
}
