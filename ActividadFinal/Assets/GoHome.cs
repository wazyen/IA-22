using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : GAction
{
    public override bool PrePerform()
    {
        AttentionTable attentionTable = gameObject.GetComponent<GAgent>().inventory.FindItemWithTag("AttentionTable").GetComponent<AttentionTable>();
        GWorld.Instance.ReturnAttentionTable(attentionTable);
        return true;
    }

    public override bool PostPerform()
    {
        Destroy(this.gameObject);
        return true;
    }
}