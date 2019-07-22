using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MultiTargetDisabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void disableMultiTargets(string dontdisable)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            MultiTargetBehaviour obj = transform.GetChild(i).gameObject.GetComponent<MultiTargetBehaviour>();
            if (obj.name == dontdisable || obj.enabled == false) continue;
            obj.enabled = false;
        }
    }


}
