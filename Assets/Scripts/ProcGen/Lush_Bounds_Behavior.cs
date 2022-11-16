using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lush_Bounds_Behavior : MonoBehaviour
{
    [Header("Radius")]
    [Tooltip("The radius of the bounding box")]
    [SerializeField] float startingRadius;

    [Header("Expansion Factor")]
    [Tooltip("How much the sphere expands when something is picked up")]
    [SerializeField] float expand;

    [Header("Green Material")]
    [Tooltip("The material the lush will be.")]
    [SerializeField] Material green;

    private SphereCollider col;
    private bool colGot = false;

    private void Awake()
    {
        col = GetComponent<SphereCollider>();
        col.radius = startingRadius;
        colGot = true;

        updateLush();
    }

    private void expandLush()
    {
        col.radius *= expand;

        updateLush();
    }

    private void updateLush()
    {
        Collider[] newLushCols = Physics.OverlapSphere(transform.position, col.radius);
        foreach (Collider modelsCol in newLushCols)
        {
            MeshRenderer modelMesh = modelsCol.GetComponent<MeshRenderer>();
            if(modelMesh != null)
                modelMesh.material = green;
        }
    }

    public void inspectorExpandLush()
    {
        if (!colGot)
        {
            col = GetComponent<SphereCollider>();
            col.radius = startingRadius;
            colGot = true;

            updateLush();
        }
        
        expandLush();
    }
}
