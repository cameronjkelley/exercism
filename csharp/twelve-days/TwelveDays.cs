using System;
using System.Collections.Generic;

public class TwelveDaysSong
{
  public string Verse(int verse)
  {
    return BuildVerse(verse);
  }
  public string Verses(int start, int stop)
  {
    string verses = "";
    for (; start <= stop; start++)
    {
      verses += BuildVerse(start) + "\n";
    }
    return verses;
  }

  public string Sing()
  {
    return Verses(1, 12);
  }

  private Dictionary<int, Tuple<string, string>> Days = new Dictionary<int, Tuple<string, string>>
  {
    { 1, Tuple.Create("first", "a Partridge in a Pear Tree") },
    { 2, Tuple.Create("second", "two Turtle Doves") },
    { 3, Tuple.Create("third", "three French Hens") },
    { 4, Tuple.Create("fourth", "four Calling Birds") },
    { 5, Tuple.Create("fifth", "five Gold Rings") },
    { 6, Tuple.Create("sixth", "six Geese-a-Laying") },
    { 7, Tuple.Create("seventh", "seven Swans-a-Swimming") },
    { 8, Tuple.Create("eighth", "eight Maids-a-Milking") },
    { 9, Tuple.Create("ninth", "nine Ladies Dancing") },
    { 10, Tuple.Create("tenth", "ten Lords-a-Leaping") },
    { 11, Tuple.Create("eleventh", "eleven Pipers Piping") },
    { 12, Tuple.Create("twelfth", "twelve Drummers Drumming") }
  };

  private string BuildVerse(int number)
  {
    string verse = "";
    if (number > 1)
    {
      for (int i = number; i > 1; i--)
      {
        verse += Days[i].Item2 + ", ";
      }
      verse += "and ";
    }
    verse += Days[1].Item2;
    return $"On the {Days[number].Item1} day of Christmas my true love gave to me, {verse}.\n";
  }
}