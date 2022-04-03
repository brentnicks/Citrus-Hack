using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planter : MonoBehaviour
{
    bool canPlant = true;
    GameManager gm;
    public GameObject seed1, seed2, seed3;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && canPlant)
            {
                plantSeed();
            }
        }
    }



    public void plantSeed()
    {
        switch (gm.currentSeed)
        {
            case 1:
                if (gm.seed1 > 0)
                {
                    --gm.seed1;
                    SpawnPlant(seed1);
                    canPlant = false;
                }

                break;
            case 2:
                if (gm.seed2 > 0)
                {
                    --gm.seed2;
                    SpawnPlant(seed2);
                    canPlant = false;
                }
                
                break;
            case 3:
                if (gm.seed3 > 0)
                {
                    --gm.seed3;
                    SpawnPlant(seed3);
                    canPlant = false;
                }
                
                break;
            default:
                Debug.Log("invalid");
                break;
        }
        gm.updateCoins();
        gm.updateSeedText();
    }

    public void SpawnPlant(GameObject seed)
    {
        Instantiate(seed, transform.position, Quaternion.identity);
    }
}
