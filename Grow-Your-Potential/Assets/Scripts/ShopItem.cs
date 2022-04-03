using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public int cost;
    public string item;
    GameManager gm;
    double distance;
    GameObject player;
    public GameObject floatingTextPrefab;
    GameObject floatingText;
    bool canBuy = false;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (canBuy && Input.GetKeyDown(KeyCode.E))
        {
            buyItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            canBuy = true;
            floatingText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            floatingText.transform.position = new Vector3(floatingText.transform.position.x, floatingText.transform.position.y + 2, 0);
            if (item == "low")
            {
                floatingText.GetComponentInChildren<TextMeshPro>().text = "Low Potential Seed";
            }
            else if (item == "medium")
            {
                floatingText.GetComponentInChildren<TextMeshPro>().text = "Medium Potential Seed";
            }
            else if (item == "high")
            {
                floatingText.GetComponentInChildren<TextMeshPro>().text = "High Potential Seed";
            }
            else if (item == "better")
            {
                floatingText.GetComponentInChildren<TextMeshPro>().text = "Iron Sword";
            }
            else if (item == "best")
            {
                floatingText.GetComponentInChildren<TextMeshPro>().text = "Gold Sword";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player && floatingText != null)
        {
            canBuy = false;
            Destroy(floatingText, .25f);
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
                case "better":
                    //implement damage increase
                    Destroy(gameObject);
                    break;

                case "best":
                    //implement better damage increase;
                    Destroy(gameObject);
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
