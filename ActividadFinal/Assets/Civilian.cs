using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : GAgent
{
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("readyToBeFrisked", 1, true);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("isAttended", 1, true);
        goals.Add(s2, 5);

        SubGoal s3 = new SubGoal("isHome", 1, false);
        goals.Add(s3, 7);
    }
}
