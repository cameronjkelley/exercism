using System;
using System.Collections.Generic;

public enum Plant
{
  Clover,
  Grass,
  Radishes,
  Violets
}

public class Garden
{
  private static string[] Students = new string[]
  {
    "Alice", "Bob", "Charlie",
    "David", "Eve", "Fred",
    "Ginny", "Harriet", "Ileana",
    "Joseph", "Kincaid", "Larry"
  };

  private static Dictionary<char, Plant> Plants = new Dictionary<char, Plant>
  {
    { 'C', Plant.Clover },
    { 'G', Plant.Grass },
    { 'R', Plant.Radishes },
    { 'V', Plant.Violets }
  };

  private static Dictionary<string, Plant[]> garden = new Dictionary<string, Plant[]>();

  public Garden(string[] students, string plants)
  {
    Array.Sort(students);
    plants = plants.Replace("\n", string.Empty);
    int halfPlants = plants.Length / 2;
    int i = 0;
    for (int j = 0; j < halfPlants; j += 2)
    {
      Plant[] seeds = {
        Plants[plants[j]],
        Plants[plants[j + 1]],
        Plants[plants[j + halfPlants]],
        Plants[plants[j + halfPlants + 1]]
      };
      string student = students[i];
      garden[student] = seeds;
      i++;
    }
  }

  public static Garden DefaultGarden(string plants)
  {
    return new Garden(Students, plants);
  }

  public Plant[] GetPlants(string student)
  {
    return garden.ContainsKey(student) ? garden[student] : new List<Plant>().ToArray();
  }
}