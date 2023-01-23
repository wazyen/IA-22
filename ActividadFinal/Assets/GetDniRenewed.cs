using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDniRenewed : GAction
{
    public override bool PrePerform()
    {
        AttentionTable attentionTable = GWorld.Instance.GetAttentionTable();
        if (attentionTable == null)
            return false;
        target = attentionTable.GetAttendedSpot();
        gameObject.GetComponent<GAgent>().inventory.AddItem(attentionTable.gameObject);

        return true;
    }

    public override bool PostPerform()
    {
        AttentionTable attentionTable = gameObject.GetComponent<GAgent>().inventory.FindItemWithTag("AttentionTable").GetComponent<AttentionTable>();
        Attendant attendant = attentionTable.GetAttendant();
        attendant.beliefs.ModifyState("dniRequested", 1);
        attendant.inventory.AddItem(gameObject);
        return true;
    }
}