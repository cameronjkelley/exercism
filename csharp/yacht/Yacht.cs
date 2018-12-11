using System;
using System.Linq;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        int score;

        switch (category)
        {
            case YachtCategory.Ones:
            case YachtCategory.Twos:
            case YachtCategory.Threes:
            case YachtCategory.Fours:
            case YachtCategory.Fives:
            case YachtCategory.Sixes:
                score = dice.Where(x => x == (int)category).Sum();
                break;
            case YachtCategory.FullHouse:
                score = dice.Distinct().Count() == 2 &&
                        (dice.Where(x => x == dice.Max()).Count() == 3 || dice.Where(x => x == dice.Min()).Count() == 3) ?
                            dice.Sum() : 0;
                break;
            case YachtCategory.FourOfAKind:
                score = dice.Where(x => x == dice.Max()).Count() >= 4 ||
                        dice.Where(x => x == dice.Min()).Count() >= 4 ?
                            dice.FirstOrDefault(x => dice.Count(y => x == y) >= 4) * 4 : 0;
                break;
            case YachtCategory.LittleStraight:
                score = dice.Distinct().Count() == 5 && dice.Sum() == 15 ? 30 : 0;
                break;
            case YachtCategory.BigStraight:
                score = dice.Distinct().Count() == 5 && dice.Sum() == 20 ? 30 : 0;
                break;
            case YachtCategory.Choice:
                score = dice.Sum();
                break;
            case YachtCategory.Yacht:
                score = dice.Distinct().Count() == 1 ? 50 : 0;
                break;
            default:
                score = 0;
                break;
        }

        return score;
    }
}

