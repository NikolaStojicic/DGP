using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoxOrderingControler
{
    private Dictionary<string, Vector3> _paletPositions;

    public BoxOrderingControler()
    {
        _paletPositions = new Dictionary<string, Vector3>();
        this.initialization();
    }

    private void initialization()
    {
        _paletPositions.Add("k7", new Vector3(-0.50f,0,0.5f));
        _paletPositions.Add("k1", new Vector3(-0.4985f,0,0.50f));
        _paletPositions.Add("k6", new Vector3(-0.4962f,0,0.50f));
        _paletPositions.Add("k5", new Vector3(-0.50f,0,0.4985f));
        _paletPositions.Add("k2", new Vector3(-0.4988f,0,0.4985f));
        _paletPositions.Add("k3", new Vector3(-0.50f,0,0.4973f));
        _paletPositions.Add("k4",new Vector3(-0.4962f,0,0.4992f));
    }


    public Vector3 getNextPositon(string name)
    {
        return this._paletPositions[name];
    }
    public IEnumerator GetEnumerator()
    {
        return this._paletPositions.GetEnumerator();
    }
}
