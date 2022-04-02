using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int health;
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
}
