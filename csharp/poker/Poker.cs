using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    public static class Poker
    {
        public static IEnumerable<string> BestHands(IEnumerable<string> hands)
        {
            Dictionary<string, List<Card>> cardsByHand = new Dictionary<string, List<Card>>();
            Dictionary<string, Ranks> ranksByHand = new Dictionary<string, Ranks>();

            foreach (string hand in hands)
            {
                cardsByHand.Add(hand, GetCards(hand));
                ranksByHand.Add(hand, RankHand(cardsByHand[hand]));
            }

            string[] bestHands = ranksByHand.Where(hand => hand.Value == ranksByHand.Values.Max()).Select(hand => hand.Key).ToArray();

            if (bestHands.Length > 1)
            {
                Dictionary<string, int> scores = new Dictionary<string, int>();

                foreach (string hand in bestHands)
                {
                    scores.Add(hand, ScoreHand(ranksByHand[hand], cardsByHand[hand]));
                }

                return scores.Where(score => score.Value == scores.Values.Max()).Select(score => score.Key).ToArray();
            }
            else
            {
                return bestHands;
            }
        }

        private static List<Card> GetCards(string hand)
        {
            List<Card> cards = new List<Card>();

            foreach (string card in hand.Split(" "))
            {
                cards.Add(Card.ParseCard(card));
            }

            return cards.ToList();
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

        private static int ScoreHand(Ranks rank, List<Card> cards)
        {
            int score;

            switch (rank)
            {
                case Ranks.StraightFlush:
                case Ranks.FourOfAKind:
                case Ranks.FullHouse:
                case Ranks.Flush:
                case Ranks.ThreeOfAKind:
                    score = cards.Sum(c => c.Value);
                    break;
                case Ranks.Straight:
                    score = IsLowStraight(cards) ? 15 : cards.Sum(c => c.Value);
                    break;
                case Ranks.TwoPair:
                    score = cards.GroupBy(c => c.Value).Where(g => g.Count() == 2).Sum(g => g.Key);
                    break;
                case Ranks.Pair:
                    score = cards.GroupBy(c => c.Value).FirstOrDefault(g => g.Count() == 2).Key;
                    break;
                default:
                    score = cards.Max(c => c.Value);
                    break;
            }

            return score;
        }

        private static bool IsStraightFlush(List<Card> cards) => IsStraight(cards) && IsFlush(cards);

        private static bool IsFourOfAKind(List<Card> cards) => cards.GroupBy(c => c.Value).Any(g => g.Count() == 4);

        private static bool IsFullHouse(List<Card> cards) => IsThreeOfAKind(cards) && IsPair(cards);

        private static bool IsFlush(List<Card> cards) => cards.All(c => c.Suit == cards[0].Suit);

        private static bool IsStraight(List<Card> cards) => IsLowStraight(cards) || !cards.OrderBy(c => c.Value).Select((c, i) => c.Value - i).Distinct().Skip(1).Any();

        private static bool IsLowStraight(List<Card> cards) => cards.Select(c => c.Value).OrderBy(c => c).SequenceEqual(new[] { 2, 3, 4, 5, 14 });

        private static bool IsThreeOfAKind(List<Card> cards) => cards.GroupBy(c => c.Value).Any(g => g.Count() == 3);

        private static bool IsTwoPair(List<Card> cards) => cards.GroupBy(c => c.Value).Count(g => g.Count() == 2) == 2;

        private static bool IsPair(List<Card> cards) => cards.GroupBy(c => c.Value).Count(g => g.Count() == 2) == 1;
    }

    struct Card
    {
        public Card(int value, string suit)
        {
            Value = value;
            Suit = suit;
        }

        public int Value { get; private set; }
        public string Suit { get; private set; }

        public static Card ParseCard(string card)
        {
            Dictionary<string, int> faceCards = new Dictionary<string, int> { { "J", 11 }, { "Q", 12 }, { "K", 13 }, { "A", 14 } };

            string cardValue = card.Substring(0, card.Length - 1);
            int value = faceCards.Keys.Contains(cardValue) ? faceCards[cardValue] : int.Parse(cardValue);

            string suit = card.Substring(card.Length - 1);

            return new Card(value, suit);
        }
    }

    enum Ranks
    {
        HighCard, Pair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush
    }
}
