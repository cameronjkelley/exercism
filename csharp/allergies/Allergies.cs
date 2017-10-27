using System.Collections.Generic;

public class Allergies
{ 
  private Dictionary<string, int> AllergenScores = new Dictionary<string, int>()
  {
    { "eggs", 1 },
    { "peanuts", 2 },
    { "shellfish", 4 },
    { "strawberries", 8 },
    { "tomatoes", 16 },
    { "chocolate", 32 },
    { "pollen", 64 },
    { "cats", 128 }
  };

  private int score;

  public Allergies(int score)
  {
    this.score = score;
  }

  public bool AllergicTo(string allergen)
  {
    return isAllergic(AllergenScores[allergen]);
  }

  public List<string> List()
  {
    List<string> allergies = new List<string>();
    foreach (var pair in AllergenScores)
    {
      if (isAllergic(pair.Value)) 
      {
        allergies.Add(pair.Key);
      }
    }
    return allergies;
  }

  private bool isAllergic(int allergen)
  {
    return (score & allergen) == allergen;
  }
}
