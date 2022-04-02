using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int health;
    public float attackDelay;
    protected bool canAttack = true;

    protected float attackTimer;
    protected GameObject player;
    protected EnemyMovement movement;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    public virtual void attack(){

    }
    public void takeDamage(){
        health--;
        if (health == 0){
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.tag == "Player"){
            Debug.Log("Hit player");
            // coll.GetComponent<PlayerCombat>().takeDamage();
        }
    }

    void Update(){
        Vector3 playerPos = player.transform.position;
        Vector3 currPos = gameObject.transform.position;
        Vector3 posDiff = playerPos - currPos;
        if (Mathf.Abs(posDiff.magnitude) < movement.targetDistance){
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
