using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnActivationObject
{
    public EffectInfo EffectInfo { get; }
    public Selector Selector { get; }
    public OnActivationObject postaction;
    public OnActivationObject(EffectInfo effectInfo, Selector selector)
    {
        EffectInfo = effectInfo;
        Selector = selector;
    }
    public OnActivationObject(EffectInfo effectInfo, Selector selector, OnActivationObject onActivationObject)
    {
        EffectInfo = effectInfo;
        Selector = selector;
        this.postaction = onActivationObject;
    }

}