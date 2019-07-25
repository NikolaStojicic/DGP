using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rand_BtnPalletPreview : MonoBehaviour
{
    Rand_ScrollView scrollViewScript;// = GameObject.FindObjectOfType<Rand_ScrollView>();

    // Start is called before the first frame update
    void Start()
    {
        scrollViewScript = GameObject.FindObjectOfType<Rand_ScrollView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void btnScrollPreview()
    {
        this.scrollViewScript.palletPreview();
    }
}
