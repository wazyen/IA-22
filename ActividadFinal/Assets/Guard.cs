using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : GAgent
{
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("civilianFrisked", 1, false);
        goals.Add(s1, 5);
        
        base.Start();
        SubGoal s2 = new SubGoal("isRested", 1, false);
        goals.Add(s2, 3);
    }
}
