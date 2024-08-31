using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAstNode{}
public interface IProgramNode : IAstNode
{
    public void Create();
    public void CreateCard();
    public void CreateEfect();
}

