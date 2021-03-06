﻿using System.Collections.Generic;
using System.Text;

public static class RomanNumerals
{
  private static Dictionary<int, string> Numerals = new Dictionary<int, string>()
  {
    { 1000, "M" }, { 900, "CM" }, 
    { 500, "D" }, { 400, "CD" }, 
    { 100, "C" }, { 90, "XC" }, 
    { 50, "L" }, { 40, "XL" }, 
    { 10, "X" }, { 9, "IX" }, 
    { 5, "V" }, { 4, "IV" }, 
    { 1, "I" }
  };

  public static string ToRoman(this int input)
  {
    StringBuilder output = new StringBuilder();
    foreach (var pair in Numerals)
    {
      while (input / pair.Key > 0)
      {
        output.Append(pair.Value);
        input -= pair.Key;
      }
    }
    return output.ToString();
  }
}
