using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBox : MonoBehaviour
{
    [SerializeField]
    private GameObject listaBox;

    private List<GameObject> listaBoxeva = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject k = listaBox.transform.GetChild(i).gameObject;
            k.transform.parent = this.gameObject.transform;
            Instantiate(k, this.transform.position, this.transform.rotation);
            listaBoxeva.Add(k); 
            //ucitaj dim
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
