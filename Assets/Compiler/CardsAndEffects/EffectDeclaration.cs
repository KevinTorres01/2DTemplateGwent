using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EffectDeclaration : IProgramNode
{
    IExpression Name;
    List<Params> Params;
    IExpression action;
    CardsAndEffects context;

    public EffectDeclaration(IExpression name, List<Params> param, IExpression Action, CardsAndEffects context)
    {
        Name = name;
        Params = param;
        action = Action;
        this.context = context;
    }
    public void CreateCard()
    {
        throw new NotImplementedException();
    }

    public void CreateEfect()
    {
        object name = Name.Evaluate();
        object Action = action.Evaluate();
        if (name is string s && Action is Action a)
        {
            context.effects.Add(s, new CompiledEffect(s, Params, a));
            return;
        }
        throw new Exception("Action and name are not in the correct format");
    }

    public void Create()
    {
        CreateEfect();
    }
}