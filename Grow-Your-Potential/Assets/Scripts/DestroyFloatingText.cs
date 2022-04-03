using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFloatingText : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f);
    }
}
