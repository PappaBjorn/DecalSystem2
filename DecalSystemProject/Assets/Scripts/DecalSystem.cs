using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalSystem : MonoBehaviour
{
    [SerializeField]
    private Mesh mesh;
    [SerializeField]
    private Material material;
    // number of decals that can be instantiated
    private const int decalIndex = 1224;
    // Create the matrix with the length of the decal index
    private Matrix4x4[] matrices = new Matrix4x4[decalIndex];
    // set the current decal number
    private int decalNum = 0;

    #region Singleton
    public static DecalSystem instance;
    private void Awake()
    {
        if(instance != null)
            Destroy(instance);
        instance = this;
    }
    #endregion

    private void Update()
    {
        // Draw the current decal using DrawMeshInstanced from matrices
        Graphics.DrawMeshInstanced(mesh, 0, material, matrices);
    }

    // function for the drawing of the decal at the position, rotation and the scale of the decal
    // Go through each and every index of the matrix with decals.
    public void DrawDecal(Vector3 position, Quaternion rotation)
    {
        matrices[decalIndex].SetTRS(position, rotation, new Vector3(0.1f, 0.1f, 0.1f));
        decalNum = (decalNum + 1) % matrices.Length;
    }
}