using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frisk : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        GameObject civilian = GWorld.Instance.RemoveFrisked();
        civilian.GetComponent<GAgent>().beliefs.ModifyState("friskCompleted", 1);
        GWorld.Instance.GetWorld().ModifyState("civilianToBeFrisked", -1);
        gameObject.GetComponent<GAgent>().beliefs.ModifyState("isRested", -1);
        return true;
    }
}