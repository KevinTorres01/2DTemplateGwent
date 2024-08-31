using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Delegate
{
    public List<Token> Identifiers { get; }
    public IExpression Expression { get; }
    public Enviroment Parent;
    public Delegate(List<Token> identifiers, IExpression expression, Enviroment Parent)
    {
        Identifiers = identifiers;
        Expression = expression;
        this.Parent = Parent;
    }

    public object Invoke(params object[] args)
    {
        if (args.Length == Identifiers.Count)
        {
            for (int i = 0; i < Identifiers.Count; i++)
            {
                Parent.SetValue(Identifiers[i].Value, args[i]);
            }
            return Expression.Evaluate();
        }
        else
        {
            throw new Exception();
        }
    }
}
