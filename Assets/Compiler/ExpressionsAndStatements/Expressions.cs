using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using System.Net.Http.Headers;

public interface IExpression : IAstNode
{
    object Evaluate();
}
public class BinaryExpression : IExpression
{
    IExpression left;
    IExpression right;
    Token Operator;
    public BinaryExpression(IExpression Left, IExpression Right, Token Operator)
    {
        left = Left;
        right = Right;
        this.Operator = Operator;

    }

    public object Evaluate()
    {
        switch (Operator.Type)
        {
            case TokenType.MUL:
                return Convert.ToDouble(left.Evaluate()) * Convert.ToDouble(right.Evaluate());
            case TokenType.DIV:
                return Convert.ToDouble(left.Evaluate()) / Convert.ToDouble(right.Evaluate());
            case TokenType.PLUS:
                return Convert.ToDouble(left.Evaluate()) + Convert.ToDouble(right.Evaluate());
            case TokenType.MINUS:
                return Convert.ToDouble(left.Evaluate()) - Convert.ToDouble(right.Evaluate());
            case TokenType.OR:
                return (bool)left.Evaluate() || (bool)right.Evaluate();
            case TokenType.AND:
                return (bool)left.Evaluate() && (bool)right.Evaluate();
            case TokenType.GREATEREQUALS:
                return Convert.ToDouble(left.Evaluate()) >= Convert.ToDouble(right.Evaluate());
            case TokenType.GREATER:
                return Convert.ToDouble(left.Evaluate()) > Convert.ToDouble(right.Evaluate());
            case TokenType.LESS:
                return Convert.ToDouble(left.Evaluate()) < Convert.ToDouble(right.Evaluate());
            case TokenType.LESSEQUALS:
                return Convert.ToDouble(left.Evaluate()) <= Convert.ToDouble(right.Evaluate());
            case TokenType.EQUALS:
                return Convert.ToDouble(left.Evaluate()) == Convert.ToDouble(right.Evaluate());
            case TokenType.CONCATWHITHOUTSPACE:
                return (string)left.Evaluate() + (string)right.Evaluate();
            case TokenType.CONCATWHITHSPACE:
                return (string)left.Evaluate() + " " + (string)right.Evaluate();
            case TokenType.POTENCIATION:
                return Math.Pow(Convert.ToDouble(left.Evaluate()), Convert.ToDouble(right.Evaluate()));
            case TokenType.ASIGNMENT:
                if (left is Variable v)
                {
                    var x = new VariableAssignation(v, right);
                    return x.Evaluate();
                }
                else if (left is GetProperties p)
                {
                    var x = new PropertySet(p, right);
                    return x.Evaluate();
                }
                else
                {
                    throw new Exception("");
                }
            default:
                return null;
        }
    }
}
public class Assignment : BinaryExpression
{
    public Assignment(IExpression Left, IExpression Right, Token Operator) : base(Left, Right, Operator)
    {
    }
}
class UnaryExpression : IExpression
{
    IExpression expression;
    Token Operator;
    public UnaryExpression(IExpression Expression, Token Operator)
    {
        expression = Expression;
        this.Operator = Operator;
    }
    public object Evaluate()
    {
        switch (Operator.Type)
        {
            case TokenType.DECREMENT:
                if (expression is Variable v)
                {
                    v.enviroment.SetValue(v.NameOfVariable, (int)expression.Evaluate() - 1);
                    return v.enviroment.GetValue(v.NameOfVariable);
                }
                throw new Exception("");
            case TokenType.MINUS:
                return -(int)expression.Evaluate();
            case TokenType.INCREMENT:
                if (expression is Variable v2)
                {
                    v2.enviroment.SetValue(v2.NameOfVariable, (double)expression.Evaluate() + 1);
                    return v2.enviroment.GetValue(v2.NameOfVariable);
                }
                throw new Exception();
            default:
                return null;
        }
    }
}
public class Atom : IExpression
{
    object value;

    public Atom(object Value)
    {
        value = Value;
    }

    public object Evaluate()
    {
        return value;
    }
}
public class ListExpression : IExpression
{
    List<IExpression> exp;
    public ListExpression(List<IExpression> expressions)
    {
        exp = expressions;
    }
    public object Evaluate()
    {
        List<object> list = new List<object>();
        foreach (var item in exp)
        {
            list.Add(item.Evaluate());
        }
        return list;
    }
}

public class Variable : IExpression
{
    public Enviroment enviroment;
    public string NameOfVariable;
    public Variable(string NameOfVariable, Enviroment actual)
    {
        this.NameOfVariable = NameOfVariable;
        enviroment = actual;
    }

    public object Evaluate()
    {
        return enviroment.GetValue(NameOfVariable);
    }
}
public class PropertySet : IExpression
{
    IExpression expression;
    IExpression value;
    public PropertySet(IExpression left, IExpression value)
    {
        this.expression = left;
        this.value = value;
    }

    public object Evaluate()
    {
        if (expression is GetProperties p)
        {
            var e = p.exp.Evaluate();
            if (e is UnitCard card)
            {
                switch (p.NameOfPropery)
                {
                    case "Power":
                        card.Score = Convert.ToInt32(value.Evaluate());
                        return value.Evaluate();
                }
            }
            else if (e is List<object> list)
            {
                switch (p.NameOfPropery)
                {
                    case "Indexer":
                        list[int.Parse(p.args[0].Evaluate().ToString())] = value.Evaluate();
                        return value.Evaluate();
                    default:
                        throw new Exception();
                }
            }
            throw new Exception();
        }
        throw new Exception();
    }
}
public class VariableAssignation : IExpression
{
    Variable variable;
    IExpression value;


    public VariableAssignation(Variable v, IExpression right)
    {
        variable = v;
        value = right;
    }

    public object Evaluate()
    {
        var x = value.Evaluate();
        variable.enviroment.SetValue(variable.NameOfVariable, x);
        return x;
    }

}
public class FunctionCall : IExpression
{
    public IExpression exp;
    string NameOfMethod;
    List<IExpression> args;
    public FunctionCall(IExpression left, string name, List<IExpression> args)
    {
        exp = left;
        NameOfMethod = name;
        this.args = args;
    }
    public object Evaluate()
    {
        var x = exp.Evaluate();
        object s = null;
        if (args.Count > 0)
        {
            s = args[0].Evaluate();
        }
        if (x is Context context)
        {
            switch (NameOfMethod)
            {
                case "HandOfPlayer":
                    if (s != null)
                    {
                        return context.HandOfPlayer(Convert.ToInt32(s));
                    }
                    throw new Exception();
                case "DeckOfPlayer":
                    if (s != null)
                    {
                        return context.DeckOfPlayer(Convert.ToInt32(s));
                    }
                    throw new Exception();
                case "GraveyardOfPlayer":
                    if (s != null)
                    {
                        return context.GraveyardOfPlayer(Convert.ToInt32(s));
                    }
                    throw new Exception();
                case "FieldOfPlayer":
                    if (s != null)
                    {
                        return context.FieldOfPlayer(Convert.ToInt32(s));
                    }
                    throw new Exception();
                default: throw new Exception();
            }
        }
        if (x is List<Card> cards)
        {
            switch (NameOfMethod)
            {
                case "Shuffle":
                    Deck.Swap(cards);
                    return typeof(void);
                case "Find":
                    return typeof(void);

            }
        }
        if (x is List<object> list)
        {
            switch (NameOfMethod)
            {
                case "Push":
                    if (args.Count > 0)
                        list.Insert(0, args[0].Evaluate());
                    else
                        throw new Exception();
                    return typeof(void);
                case "SendButton":
                    if (args.Count > 0)
                        list.Add(args[0].Evaluate());
                    else
                        throw new Exception();
                    return typeof(void);
                case "Pop":
                    list.RemoveAt(list.Count - 1);
                    return typeof(void);
                default: throw new Exception();
            }
        }
        throw new Exception();
    }

}
public class ActionExpression : IExpression
{
    public List<Token> Identifiers { get; }
    public List<IStatements> Statements { get; }
    public Enviroment Parent { get; }

    public ActionExpression(List<Token> identifiers, List<IStatements> statements, Enviroment Parent)
    {
        Identifiers = identifiers;
        Statements = statements;
        this.Parent = Parent;
    }
    public object Evaluate()
    {
        return new Action(Identifiers, Statements, Parent);
    }
}
public class GetProperties : IExpression
{
    public IExpression exp;
    public string NameOfPropery;
    public List<IExpression> args;
    public GetProperties(IExpression left, string name, List<IExpression> args)
    {
        exp = left;
        NameOfPropery = name;
        this.args = args;
    }
    public object Evaluate()
    {
        var x = exp.Evaluate();
        Debug.Log(x + x.GetType().ToString());
        if (x is Context context)
        {
            switch (NameOfPropery)
            {
                case "Hand":
                    return context.Hand;
                case "Deck":
                    return context.Deck;
                case "Board":
                    return context.Board;
                case "Graveyard":
                    return context.Graveyard;
                case "Field":
                    return context.Field;
                case "TrigerPlayer":
                    return context.TrigerPlayer;
                default: throw new Exception();
            }
        }
        else if (x is UnitCard card)
        {
            switch (NameOfPropery)
            {
                case "Power":
                    return card.Score;
                case "Type":
                    return card.Type;
                default:
                    throw new Exception();
            }
        }
        else if (x is List<Card> cards)
        {
            switch (NameOfPropery)
            {
                case "Count":
                    return cards.Count;
                case "Indexer":
                    return cards[int.Parse(args[0].Evaluate().ToString())];
                default: throw new Exception();
            }
        }
        else if (x is List<object> list)
        {
            switch (NameOfPropery)
            {
                case "Count":
                    return list.Count;
                case "Indexer":
                    return list[int.Parse(args[0].Evaluate().ToString())];
                default: throw new Exception();
            }
        }
        else
            throw new Exception();
    }
}
public class DelegateExpression : IExpression
{
    List<Token> Identifiers;
    IExpression expression;
    Enviroment enviroment;
    public DelegateExpression(IExpression expression, List<Token> tokens, Enviroment Parent)
    {
        this.expression = expression;
        Identifiers = tokens;
        enviroment = Parent;

    }

    public object Evaluate()
    {
        return new Delegate(Identifiers, expression, enviroment);
    }
}
public class EffectInfoExpression : IExpression
{
    public Dictionary<string, IExpression> paramsValues;
    public IExpression Name;
    public CardsAndEffects Context;

    public EffectInfoExpression(Dictionary<string, IExpression> paramsValues, IExpression name, CardsAndEffects context)
    {
        this.paramsValues = paramsValues;
        Name = name;
        Context = context;
    }

    public object Evaluate()
    {
        object name = Name.Evaluate();
        Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
        if (name is string s && Context.effects.ContainsKey(s) && paramsValues.Count == Context.effects[s].Params.Count)
        {
            foreach (var item in Context.effects[s].Params)
            {
                var nam = item.Name;
                var value = paramsValues[nam].Evaluate();
                if (value is double d && item.type == TokenType.NUMBER)
                {
                    keyValuePairs.Add(nam, d);
                }
                else if (value is string k && item.type == TokenType.STRINGKEYWORD)
                {
                    keyValuePairs.Add(nam, k);
                }
                else if (value is bool m && item.type == TokenType.BOOL)
                {
                    keyValuePairs.Add(nam, m);
                }
                else
                {
                    throw new Exception("");
                }

            }
            return new EffectInfo(s, keyValuePairs);
        }
        throw new Exception("");

    }
}
public class OnActivationObjectExpression : IExpression
{
    EffectInfoExpression effect;
    SelectorExpression selector;
    OnActivationObjectExpression PostAction;
    public OnActivationObjectExpression(EffectInfoExpression effect, SelectorExpression selector, OnActivationObjectExpression postact)
    {
        this.effect = effect;
        this.selector = selector;
        PostAction = postact;
    }

    public object Evaluate()
    {
        object eff = effect.Evaluate();
        object sel = selector.Evaluate();
        if (eff is EffectInfo effectInfo && sel is Selector selectorinf)
        {
            if (PostAction == null)
            {
                return new OnActivationObject(effectInfo, selectorinf);
            }
            else
            {
                var postAction = PostAction.Evaluate();
                if (postAction is OnActivationObject onActivationObject)
                {
                    return new OnActivationObject(effectInfo, selectorinf, onActivationObject);

                }
                else
                {
                    throw new Exception();
                }
            }
        }
        throw new Exception();
    }
}
public class SelectorExpression : IExpression
{
    public IExpression Source;
    public IExpression Single;
    public IExpression predicate;
    public SelectorExpression(IExpression Source, IExpression Single, IExpression predicate)
    {
        this.Source = Source;
        this.Single = Single;
        this.predicate = predicate;
    }

    public object Evaluate()
    {
        object sourc = Source.Evaluate();
        object sing = Single.Evaluate();
        object pred = predicate.Evaluate();

        if (sourc is string a && sing is bool b && pred is Delegate j)
        {
            return new Selector(a, b, j);

        }
        throw new Exception();
    }
}
