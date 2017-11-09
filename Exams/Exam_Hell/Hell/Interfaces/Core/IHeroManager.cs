using System;
using System.Collections.Generic;

public interface IHeroManager
{
    string AddHero(List<string> arguments);
    string AddItemToHero(List<String> arguments);
    string AddRecipeToHero(List<String> arguments);
    string Inspect(List<String> arguments);
    string PrintAllHeroes();
}