using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsAndEffects
{
   public Dictionary<string, CompiledEffect> effects = new Dictionary<string, CompiledEffect>(){
      {"",new CompiledEffect("",null,null)}};
   public Dictionary<string, CompiledCard> cards = new Dictionary<string, CompiledCard>();
}