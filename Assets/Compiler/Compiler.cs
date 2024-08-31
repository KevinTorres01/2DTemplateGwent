using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Compiler
{
    public static readonly Enviroment enviroment = new Enviroment();
    static Compiler()
    { }
    public static CardsAndEffects Compile(string s)
    {
        Debug.Log("Entro a Compilar");
        Lexer lexer = new Lexer();
        List<Token> listofToken = lexer.Tokenizer(s);
        lexer.FixErrors();
        if (lexer.Errors.Count > 0)
        {
            string mess = "Invalid Token :";
            foreach (var item in lexer.Errors)
            {
                mess += item.Key;
            }
            throw new Exception(mess);
        }
        Debug.Log("Paso el lexer");
        Parser parser = new Parser(listofToken);
        List<IProgramNode> ToCompile = parser.Program(new Enviroment());
        Debug.Log("Paso el parser");
        foreach (var item in ToCompile)
        {
            item.Create();
        }
        Debug.Log("Paso el evaluador");
        return parser.context;
    }
}