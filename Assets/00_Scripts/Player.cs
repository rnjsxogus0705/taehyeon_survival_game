using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public float detectionRadius;
    public LayerMask monsterLayer;
    
    public Transform target
    {
        get { return GetNearestMonster(); }
    }
    
    public Vector3 Direction()
    {
        Vector3 dirToMonster = (target.position - transform.position).normalized;
        return dirToMonster;
    }
    public Transform GetNearestMonster()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, monsterLayer);
        Transform nearest = null;
        float minDist = Mathf.Infinity;

        foreach (Collider col in hits)
        {
            float dist = Vector3.Distance(transform.position, col.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = col.transform;
            }
        }

        return nearest;
    }
}