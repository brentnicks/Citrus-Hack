using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public int cost;
    public string item;
    GameManager gm;
    double distance;
    GameObject player;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance < 0.5)
        {
            buyItem();
        }
    }

    public void buyItem()
    {
        if (gm.coins >= cost)
        {
            gm.coins -= cost;
            
            switch (item)
            {
                case "low":
                    ++gm.seed1;
                    break;
                case "medium":
                    ++gm.seed2;
                    break;
                case "high":
                    ++gm.seed3;
                    break;
                default:
                    Debug.Log("Invalid");
                    break;
            }
            Debug.Log("coins: " + gm.coins);
            Debug.Log("seed1: " + gm.seed1);
            gm.updateSeedText();
            gm.updateCoins();
        }
    }


}
