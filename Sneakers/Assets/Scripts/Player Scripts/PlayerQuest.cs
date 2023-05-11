using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public Quest quest;
    // Start is called before the first frame update
    void Start()
    {
        if (quest.isActive)
        {
            if (quest.goal.target == Target.Cyborgs)
            {
                quest.goal.EnemyKilled();
                if (quest.goal.IsReached())
                {
                    quest.Complete();
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
