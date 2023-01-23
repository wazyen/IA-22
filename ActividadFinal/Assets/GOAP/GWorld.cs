using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;

    private static GameObject civilianBeingFrisked;
    private static Queue<AttentionTable> attentionTables;
    private static List<GameObject> copiers;


    static GWorld()
    {
        world = new WorldStates();

        attentionTables = new Queue<AttentionTable>();
        GameObject[] attTables = GameObject.FindGameObjectsWithTag("AttentionTable");
        foreach (GameObject attTableGo in attTables)
        {
            AttentionTable attTable = attTableGo.GetComponent<AttentionTable>();
            if (attTable != null)
            {
                attentionTables.Enqueue(attTable);
            }
        }

        copiers = new List<GameObject>();
        GameObject[] cprs = GameObject.FindGameObjectsWithTag("Copier");
        foreach (GameObject copier in cprs)
            copiers.Add(copier);

        Time.timeScale = 5;

    }

    private GWorld()
    {
    }

    public bool TryGetFrisked(GameObject civilian)
    {
        if (civilianBeingFrisked != null)
        {
            return false;
        }

        civilianBeingFrisked = civilian;
        return true;
    }
    public GameObject RemoveFrisked()
    {
        GameObject civilian = civilianBeingFrisked;
        civilianBeingFrisked = null;
        return civilian;
    }

    public AttentionTable GetAttentionTable()
    {
        if (attentionTables.Count == 0) return null;
        return attentionTables.Dequeue();
    }
    public void ReturnAttentionTable(AttentionTable attTable)
    {
        attentionTables.Enqueue(attTable);
    }

    public GameObject GetClosestAvailableCopier(Vector3 refPosition)
    {
        if (copiers.Count == 0) return null;
        GameObject closestCopier = null;
        float closestDist = Single.PositiveInfinity;
        foreach (GameObject copier in copiers)
        {
            float dist = Vector3.Distance(refPosition, copier.transform.position);
            if (dist < closestDist)
            {
                closestCopier = copier;
                closestDist = dist;
            }
        }

        copiers.Remove(closestCopier);
        return closestCopier;
    }
    public void ReturnCopier(GameObject copier)
    {
        copiers.Add(copier);
    }



    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
