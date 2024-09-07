using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector
{
   public string source;
   public bool single;
   public Delegate Delegate;
    public Selector(string source, bool single, Delegate predicate)
    {
        this.source = source;
        this.single = single;
        Delegate = predicate;
    }
}