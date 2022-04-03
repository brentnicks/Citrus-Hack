using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;
    private GameManager gm;
    void Start(){
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            gm.coins += coinValue;
            Destroy(this.gameObject);
        }
    }
}
