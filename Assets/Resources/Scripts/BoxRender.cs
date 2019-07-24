using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for geting dimensions and position for rendering at the Ground Plane 
/// </summary>
public class BoxRender : MonoBehaviour
{

    [SerializeField]
    private GameObject boxPrefab;
    private Dictionary<string,GameObject> dictBox;

    /// <summary>
    /// Dohvata poziciju i dimenzije kutije, koju postavlja na GroundPlane
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pos"></param>
    /// <param name="size"></param>
    public void RenderBox(string name, Vector3 pos, Vector3 size)
    {
        if (!dictBox.ContainsKey(name))
        {
            GameObject b = Instantiate(boxPrefab, this.transform.GetChild(0).transform);
            b.transform.localPosition = pos;

            Vector3 vecTmp = new Vector3(0, 0, 0);
            vecTmp.y = 0.01f;

            b.transform.localScale = size + vecTmp;
            b.transform.rotation = transform.rotation;
            dictBox.Add(name, b);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dictBox = new Dictionary<string, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
