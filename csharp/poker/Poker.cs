using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public static class Poker
    {
        public static IEnumerable<string> BestHands(IEnumerable<string> input)
        {
            List<Hand> hands = new List<Hand>();
            foreach (string hand in input)
            {
                Hand newHand = new Hand(hand, Card.GetCards(hand));
                newHand.Rank = RankHand(newHand.Cards);
                hands.Add(newHand);
            }
            Hand[] bestHands = hands.Where(hand => (int)hand.Rank == hands.Max(h => (int)h.Rank)).Select(h => h).ToArray();
            if (bestHands.Length > 1)
            {
                foreach (Hand hand in bestHands)
                {
                    hand.Score = ScoreHand(hand.Rank, hand.Cards);
                }
                bestHands = bestHands.Where(hand => hand.Score == bestHands.Max(h => h.Score)).ToArray();
            }
            return bestHands.Select(hand => hand.ToString()).ToArray();
        }

        private static Ranks RankHand(List<Card> cards)
        {
            Ranks rank;
            if (IsStraightFlush(cards)) rank = Ranks.StraightFlush;
            else if (IsFourOfAKind(cards)) rank = Ranks.FourOfAKind;
            else if (IsFullHouse(cards)) rank = Ranks.FullHouse;
            else if (IsFlush(cards)) rank = Ranks.Flush;
            else if (IsStraight(cards)) rank = Ranks.Straight;
            else if (IsThreeOfAKind(cards)) rank = Ranks.ThreeOfAKind;
            else if (IsTwoPair(cards)) rank = Ranks.TwoPair;
            else if (IsPair(cards)) rank = Ranks.Pair;
            else rank = Ranks.HighCard;
            return rank;
        }

        private static bool IsStraightFlush(List<Card> cards) => IsStraight(cards) && IsFlush(cards);

        private static bool IsFourOfAKind(List<Card> cards) => cards.GroupBy(c => c.Value).Any(g => g.Count() == 4);

        private static bool IsFullHouse(List<Card> cards) => IsThreeOfAKind(cards) && IsPair(cards);

        private static bool IsFlush(List<Card> cards) => cards.All(c => c.Suit == cards.First().Suit);

        private static bool IsStraight(List<Card> cards) => !cards.OrderBy(c => c.Value).Select((c, i) => c.Value - i).Distinct().Skip(1).Any() || IsLowStraight(cards);

        private static bool IsLowStraight(List<Card> cards) => cards.Select(c => c.Value).OrderBy(c => c).SequenceEqual(new[] { 2, 3, 4, 5, 14 });

        private static bool IsThreeOfAKind(List<Card> cards) => cards.GroupBy(c => c.Value).Any(g => g.Count() == 3);

        private static bool IsTwoPair(List<Card> cards) => cards.GroupBy(c => c.Value).Count(g => g.Count() == 2) == 2;

        private static bool IsPair(List<Card> cards) => cards.GroupBy(c => c.Value).Any(g => g.Count() == 2);

        private static int ScoreHand(Ranks rank, List<Card> cards)
        {
            int score;
            switch (rank)
            {
                case Ranks.StraightFlush:
                case Ranks.FourOfAKind:
                case Ranks.FullHouse:
                case Ranks.Flush:
                case Ranks.Straight:
                case Ranks.ThreeOfAKind:
                    score = IsLowStraight(cards) ? 15 : cards.Sum(c => c.Value);
                    break;
                case Ranks.TwoPair:
                    score = cards.GroupBy(c => c.Value).Where(g => g.Count() == 2).Sum(g => (int)Math.Pow(g.Key, 2)) + GetKickers(cards);
                    break;
                case Ranks.Pair:
                    score = cards.GroupBy(c => c.Value).FirstOrDefault(g => g.Count() == 2).Key + GetKickers(cards);
                    break;
                default:
                    score = (int)Math.Pow(cards.Max(c => c.Value), 2) + cards.Sum(c => c.Value);
                    break;
            }
            return score;
        }

        private static int GetKickers(List<Card> cards)
        {
            return (int)cards.GroupBy(c => c.Value).Where(g => g.Count() == 1).Average(g => g.Key);
        }

        private class Hand
        {
            private readonly string _hand;

            public Hand(string hand, List<Card> cards)
            {
                _hand = hand;
                Cards = cards;
            }

            public List<Card> Cards { get; private set; }
            public Ranks Rank { get; set; }
            public int Score { get; set; }

            public override string ToString()
            {
                return _hand;
            }
        }

        private struct Card
        {
            public Card(int value, string suit)
            {
                Value = value;
                Suit = suit;
            }

            public int Value { get; private set; }
            public string Suit { get; private set; }

            public static List<Card> GetCards(string input)
            {
                List<Card> cards = new List<Card>();
                foreach (string card in input.Split(" "))
                {
                    cards.Add(ParseCard(card));
                }
                return cards.ToList();
            }

            private static Card ParseCard(string input)
            {
                string sub = input.Substring(0, input.Length - 1);
                Dictionary<string, int> faceCards = new Dictionary<string, int> { { "J", 11 }, { "Q", 12 }, { "K", 13 }, { "A", 14 } };
                int value = faceCards.Keys.Contains(sub) ? faceCards[sub] : int.Parse(sub);
                string suit = input.Substring(input.Length - 1);
                return new Card(value, suit);
            }
        }

        private enum Ranks
        {
            HighCard, Pair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush
        }
    }
}
