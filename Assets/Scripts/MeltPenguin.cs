using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltPenguin : MonoBehaviour
{
    [SerializeField] private LayerMask fireball;
    private int i = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == fireball)
        {

            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }
        gameObject.GetComponent<MeshFilter>().mesh = new Mesh();
        gameObject.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
    }
}
