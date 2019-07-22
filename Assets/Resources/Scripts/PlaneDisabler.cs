using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

/// <summary>
/// A custum handeler for disable Ground Plane once it's founded 
/// </summary>
public class PlaneDisabler : MonoBehaviour
{
    public void StageOnlyOnce()
    {
        this.gameObject.GetComponent<AnchorInputListenerBehaviour>().gameObject.SetActive(false);
        this.gameObject.GetComponent<PlaneFinderBehaviour>().gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            this.gameObject.GetComponent<AnchorInputListenerBehaviour>().gameObject.SetActive(false);
            this.gameObject.GetComponent<PlaneFinderBehaviour>().gameObject.SetActive(false);
        }
    }
}
