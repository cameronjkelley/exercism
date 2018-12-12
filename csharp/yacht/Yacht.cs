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
        switch (category)
        {
            case YachtCategory.Ones:
            case YachtCategory.Twos:
            case YachtCategory.Threes:
            case YachtCategory.Fours:
            case YachtCategory.Fives:
            case YachtCategory.Sixes:
                return dice.Where(x => x == (int)category).Sum();
            case YachtCategory.FullHouse:
                return IsFullHouse(dice) ? dice.Sum() : 0;
            case YachtCategory.FourOfAKind:
                return IsFourOfAKind(dice) ? GetFourOfAKindTotal(dice) : 0;
            case YachtCategory.LittleStraight:
                return IsLittleStraight(dice) ? 30 : 0;
            case YachtCategory.BigStraight:
                return IsBigStraight(dice) ? 30 : 0;
            case YachtCategory.Choice:
                return dice.Sum();
            case YachtCategory.Yacht:
                return dice.Distinct().Count() == 1 ? 50 : 0;
            default:
                return 0;
        }
    }

    private static bool IsFullHouse(int[] dice) => 
        dice.Distinct().Count() == 2 && (dice.Where(x => x == dice.Max()).Count() == 3 || dice.Where(x => x == dice.Min()).Count() == 3);

    private static bool IsFourOfAKind(int[] dice) => 
        dice.Where(x => x == dice.Max()).Count() >= 4 || dice.Where(x => x == dice.Min()).Count() >= 4;

    private static int GetFourOfAKindTotal(int[] dice) => 
        dice.FirstOrDefault(x => dice.Count(y => x == y) >= 4) * 4;

    private static bool IsLittleStraight(int[] dice) => 
        IsStraight(dice, 15);

    private static bool IsBigStraight(int[] dice) => 
        IsStraight(dice, 20);

    private static bool IsStraight(int[] dice, int sum) => 
        dice.Distinct().Count() == 5 && dice.Sum() == sum;
}
