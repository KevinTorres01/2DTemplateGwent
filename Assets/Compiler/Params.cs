using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Params
{
    public string Name;
    public TokenType type;
    public Params(string name, TokenType tokenType)
    {
        Name = name;
        type = tokenType;
    }
}