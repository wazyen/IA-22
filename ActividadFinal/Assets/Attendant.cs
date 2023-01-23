using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attendant : GAgent
{
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("dniDelivered", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("isAttending", 1, false);
        goals.Add(s2, 3);
        
        // Invoke("GetTired", Random.Range(10, 20));
    }

    // void GetTired()
    // {
    //     beliefs.ModifyState("isRested", -1);
    //     Invoke("GetTired", Random.Range(10, 20));
    // }
}
