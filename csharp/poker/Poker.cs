using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker
{
    public static class Poker
    {
        public static IEnumerable<string> BestHands(IEnumerable<string> hands)
        {
            Dictionary<string, Ranks> ranks = new Dictionary<string, Ranks>();

            foreach (string hand in hands)
            {
                ranks.Add(hand, RankHand(hand));
            }

            string[] bestHands = ranks.Where(hand => hand.Value == ranks.Values.Max()).Select(hand => hand.Key).ToArray();

            if (bestHands.Length > 1)
            {
                Dictionary<string, int> scores = new Dictionary<string, int>();

                foreach (string hand in bestHands)
                {
                    scores.Add(hand, ScoreHand(hand, ranks[hand]));
                }

                return scores.Where(score => score.Value == scores.Values.Max()).Select(score => score.Key).ToArray();
            }
            else
            {
                return bestHands;
            }
        }

        private static Ranks RankHand(string hand)
        {
            List<Card> cards = GetCards(hand);
            Ranks rank;

            if (HasStraightFlush(cards)) rank = Ranks.StraightFlush;
            else if (HasFourOfAKind(cards)) rank = Ranks.FourOfAKind;
            else if (HasFullHouse(cards)) rank = Ranks.FullHouse;
            else if (HasFlush(cards)) rank = Ranks.Flush;
            else if (HasStraight(cards)) rank = Ranks.Straight;
            else if (HasThreeOfAKind(cards)) rank = Ranks.ThreeOfAKind;
            else if (HasTwoPair(cards)) rank = Ranks.TwoPair;
            else if (HasPair(cards)) rank = Ranks.Pair;
            else rank = Ranks.HighCard;

            return rank;
        }

        private static int ScoreHand(string hand, Ranks rank)
        {
            List<Card> cards = GetCards(hand);
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

        private static List<Card> GetCards(string hand)
        {
            Dictionary<string, int> faceCards = new Dictionary<string, int> { { "J", 11 }, { "Q", 12 }, { "K", 13 }, { "A", 14 } };
            List<Card> cards = new List<Card>();

            foreach (string card in hand.Split(" "))
            {
                string cardValue = card.Substring(0, card.Length - 1);
                int value = faceCards.Keys.Contains(cardValue) ? faceCards[cardValue] : int.Parse(cardValue);

                string suit = card.Substring(card.Length - 1);

                cards.Add(new Card(value, suit));
            }

            return cards.ToList();
        }

        private static bool HasStraightFlush(List<Card> cards) => HasStraight(cards) && HasFlush(cards);

        private static bool HasFourOfAKind(List<Card> cards) => cards.GroupBy(c => c.Value).Any(g => g.Count() == 4);

        private static bool HasFullHouse(List<Card> cards) => HasThreeOfAKind(cards) && HasPair(cards);

        private static bool HasFlush(List<Card> cards) => cards.All(c => c.Suit == cards[0].Suit);

        private static bool HasStraight(List<Card> cards) => IsLowStraight(cards) || !cards.OrderBy(c => c.Value).Select((c, i) => c.Value - i).Distinct().Skip(1).Any();

        private static bool IsLowStraight(List<Card> cards) => cards.All(card => new int[] { 2, 3, 4, 5, 14 }.Contains(card.Value));

        private static bool HasThreeOfAKind(List<Card> cards) => cards.GroupBy(c => c.Value).Any(g => g.Count() == 3);

        private static bool HasTwoPair(List<Card> cards) => cards.GroupBy(c => c.Value).Count(g => g.Count() == 2) == 2;

        private static bool HasPair(List<Card> cards) => cards.GroupBy(c => c.Value).Count(g => g.Count() == 2) == 1;
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
    }

    enum Ranks
    {
        HighCard, Pair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush
    }
}
