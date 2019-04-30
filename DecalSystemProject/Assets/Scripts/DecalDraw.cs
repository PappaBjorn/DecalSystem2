using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalDraw : MonoBehaviour
{
    public GameObject decalPrefab;

    void drawADecal()
    {
        Instantiate(decalPrefab, transform.position, Quaternion.identity);
    }
}
