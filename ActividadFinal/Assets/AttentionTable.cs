using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttentionTable : MonoBehaviour
{
    private Attendant attendant;
    private GameObject attendingSpot;
    private GameObject attendedSpot;

    void Start()
    {
        attendant = gameObject.GetComponentInChildren<Attendant>();
        foreach(Transform t in transform)
        {
            switch (t.tag)
            {
                case "AttendingSpot":
                    attendingSpot = t.gameObject;
                    break;
                case "AttendedSpot":
                    attendedSpot = t.gameObject;
                    break;
            }
        }
    }

    public Attendant GetAttendant()
    {
        return attendant;
    }

    public GameObject GetAttendingSpot()
    {
        return attendingSpot;
    }

    public GameObject GetAttendedSpot()
    {
        return attendedSpot;
    }
}
