using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planter : MonoBehaviour
{
    public bool canPlant = true;
    GameManager gm;
    public GameObject seed1, seed2, seed3;
    public GameObject enemy1, enemy2, enemy3;
    private AudioSource source;
    int seed = 0;
    GameObject currSeed;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        source = gameObject.GetComponent<AudioSource>();
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
                    seed = 1;
                    SpawnPlant(seed1);
                    source.Play();
                    canPlant = false;
                }

                break;
            case 2:
                if (gm.seed2 > 0)
                {
                    --gm.seed2;
                    seed = 2;
                    SpawnPlant(seed2);
                    source.Play();
                    canPlant = false;
                }
                
                break;
            case 3:
                if (gm.seed3 > 0)
                {
                    --gm.seed3;
                    seed = 3;
                    SpawnPlant(seed3);
                    source.Play();
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
        currSeed = Instantiate(seed, transform.position, Quaternion.identity);
    }

    public void hatchEnemy()
    {
        Destroy(currSeed);
        if (seed == 1) Instantiate(enemy1, transform.position, Quaternion.identity);
        if (seed == 2) Instantiate(enemy2, transform.position, Quaternion.identity);
        if (seed == 3) Instantiate(enemy3, transform.position, Quaternion.identity);
        seed = 0;

    }
}
