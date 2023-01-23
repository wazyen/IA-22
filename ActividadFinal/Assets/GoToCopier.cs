using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCopier : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetClosestAvailableCopier(transform.position);
        if (target == null)
            return false;
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.ReturnCopier(target);
        return true;
    }
}