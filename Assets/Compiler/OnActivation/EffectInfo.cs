using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectInfo
{
    public Dictionary<string, object> Params = new Dictionary<string, object>();
    public string name;
    public EffectInfo(string name, Dictionary<string, object> Params)
    {
        this.name = name;
        this.Params = Params;
    }
}