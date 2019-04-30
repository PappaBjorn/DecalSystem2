using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalController : MonoBehaviour
{
#pragma warning disable
/*    [SerializeField] private Transform decal;*/
    [SerializeField] private LayerMask layer;
    private float spawnOffset = 0.01f;
    

#pragma warning restore

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnDecal();
        }
    }

    private void SpawnDecal()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            Vector3 position = hit.point + hit.normal * 0.01f;
            Quaternion rotation = Quaternion.LookRotation(-hit.normal, Vector3.up);
            ObjectPool.instance.SpawnFromPool("Decal", position, rotation);
        }
    }
}