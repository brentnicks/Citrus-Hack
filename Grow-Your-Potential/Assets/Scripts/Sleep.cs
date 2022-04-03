using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sleep : MonoBehaviour
{
    public GameManager gm;
    public GameObject floatingTextPrefab;
    GameObject floatingText;
    bool canSleep = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canSleep)
        {
            gm.removeAllEnemies();
            gm.increaseDayNumber();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canSleep = true;
        floatingText = Instantiate(floatingTextPrefab, transform.position + new Vector3(0, 2f, 0), Quaternion.identity);
        floatingText.GetComponentInChildren<TextMeshPro>().text = "Sleep";
        floatingText.GetComponentInChildren<TextMeshPro>().enableWordWrapping = false;
        floatingText.GetComponentInChildren<TextMeshPro>().fontSize = 15;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (floatingText != null) Destroy(floatingText, .25f);
        canSleep = false;
    }
}
