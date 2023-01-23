using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverDni : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        gameObject.GetComponent<GAgent>().beliefs.ModifyState("dniRequested", -1);
        GameObject civilianGo = gameObject.GetComponent<GAgent>().inventory.FindItemWithTag("Civilian");
        gameObject.GetComponent<Attendant>().inventory.RemoveItem(civilianGo);
        Civilian civilian = civilianGo.GetComponent<Civilian>();
        civilian.beliefs.ModifyState("hasDniRenewed", 1);
        return true;
    }
}