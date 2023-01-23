using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFrisked : GAction
{
    public override bool PrePerform()
    {
        if (GWorld.Instance.GetWorld().HasState("civilianToBeFrisked"))
        {
            return false;
        }

        if (!GWorld.Instance.TryGetFrisked(this.gameObject))
        {
            return false;
        }
        
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("civilianToBeFrisked", 1);
        return true;
    }
}