using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltPenguin : MonoBehaviour
{
    [SerializeField] private LayerMask fireball;
    [SerializeField] private Material pinguMaterial;
    private int i = 0;
    private Vector3 tempTransform;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == fireball)
        {

            gameObject.SetActive(false);
        }
    }

    private void CombineMesh()
    {
        tempTransform = gameObject.transform.parent.parent.transform.position;
        gameObject.transform.parent.parent.transform.position = Vector3.zero;
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshCollider>();
        gameObject.AddComponent<MeshRenderer>().material = pinguMaterial;
        gameObject.GetComponent<MeshFilter>().mesh = new Mesh();
        gameObject.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
        gameObject.transform.parent.parent.transform.position = tempTransform;
        gameObject.SetActive(true);
    }

    private void Start()
    {
        CombineMesh();
    }
}
