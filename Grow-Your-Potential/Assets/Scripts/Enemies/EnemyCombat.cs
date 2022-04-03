using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int health;
    public float attackDelay;
    public float recoilForce = 50f; 

    public Rigidbody2D enemyRigidBody; 

    protected bool canAttack = true;
    protected float attackTimer = 0;
    protected GameObject player;
    protected EnemyMovement movement;
    public GameObject coin;

    protected virtual void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        movement = gameObject.GetComponent<EnemyMovement>();
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>(); 
    }
    
    public virtual void attack(){

    }
    public void takeDamage(){
        GameObject newObj = this.gameObject;
        if (health == 0){
            Instantiate(coin, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else
        {
            health--;
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
