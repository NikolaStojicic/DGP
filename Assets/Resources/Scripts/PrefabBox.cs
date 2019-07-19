using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBox : MonoBehaviour
{
    private List<GameObject> listaMultiTargeta;
    [SerializeField]
    private GameObject colliderPrefab;
    private XML_Nikola xml_reader;
    private List<GameObject> listaCollidera;
    // Start is called before the first frame update
    void Start()
    {
        listaCollidera = new List<GameObject>();
        xml_reader = GameObject.FindObjectOfType<XML_Nikola>();
        listaMultiTargeta = new List<GameObject>();
        for (int i = 0; i < 7; i++)
        {
            GameObject b = this.transform.GetChild(i).gameObject;
            Vector3 size = xml_reader.getSizeByName(b.name);
            GameObject col = Instantiate(colliderPrefab, b.transform);
            col.transform.localScale = size * 1.1f;
            listaCollidera.Add(col);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
