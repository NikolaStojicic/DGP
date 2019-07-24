using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Controller : MonoBehaviour
{
    [SerializeField]
    private Material green;
    [SerializeField]
    private Material red;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
    }

    private Vector3[] getCornersOfBoxCollider(GameObject b)
    {
        Vector3[] verts = new Vector3[8];
        verts[0] = b.transform.position + new Vector3(-b.transform.localScale.x, -b.transform.localScale.y, -b.transform.localScale.z) * 0.5f;
        verts[1] = b.transform.position + new Vector3(-b.transform.localScale.x, -b.transform.localScale.y, b.transform.localScale.z) * 0.5f;
        verts[2] = b.transform.position + new Vector3(-b.transform.localScale.x, b.transform.localScale.y, -b.transform.localScale.z) * 0.5f;
        verts[3] = b.transform.position + new Vector3(-b.transform.localScale.x, b.transform.localScale.y, b.transform.localScale.z) * 0.5f;
        verts[4] = b.transform.position + new Vector3(b.transform.localScale.x, -b.transform.localScale.y, -b.transform.localScale.z) * 0.5f;
        verts[5] = b.transform.position + new Vector3(b.transform.localScale.x, -b.transform.localScale.y, b.transform.localScale.z) * 0.5f;
        verts[6] = b.transform.position + new Vector3(b.transform.localScale.x, b.transform.localScale.y, -b.transform.localScale.z) * 0.5f;
        verts[7] = b.transform.position + new Vector3(b.transform.localScale.x, b.transform.localScale.y, b.transform.localScale.z) * 0.5f;
        return verts;
    }

    public void OnTriggerStay(Collider other)
    {
        // Krajnje tacke Red boxa
        Vector3[] verts = getCornersOfBoxCollider(other.gameObject);
        int numOfVertsContained = 0;

        for (int i = 0; i < verts.Length; i++)
        {
            //Debug.Log(verts[i]);
            //Vector3 vec = verts[i]; 
            if (GetComponent<Collider>().bounds.Contains(verts[i]))
                numOfVertsContained++;
        }
        Debug.Log(numOfVertsContained);

        //if (GetComponent<Collider>().bounds.Contains(verts[0]))
        //    numOfVertsContained++;
        //if (GetComponent<Collider>().bounds.Contains(verts[1]))
        //    numOfVertsContained++;
        //if (GetComponent<Collider>().bounds.Contains(verts[3]))
        //    numOfVertsContained++;
        //if (GetComponent<Collider>().bounds.Contains(verts[7]))
        //    numOfVertsContained++;

        //Ukoliko je kutija na tacnoj poziciji
        if (numOfVertsContained >= 7)
        {
            GetComponent<MeshRenderer>().material = green;
            GameObject.Destroy(this.gameObject);
           
        }
        else
        {
            GetComponent<MeshRenderer>().material = red;
        }
    }
}
