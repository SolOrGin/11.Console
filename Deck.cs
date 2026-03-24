using System;
using System.Collections.Generic;

public class Deck
{
    private List<Card> cards = new List<Card>();
    private Random rng = new Random();

    public Deck()
    {
        for (int i = 0; i < Card.Suits.Length; i++)
        {
            for (int j = 0; j < Card.Values.Length; j++)
            {
                cards.Add(new Card(Card.Suits[i], Card.Values[j]));
            }
        }
        Shuffle(); 
    }

    private void Shuffle()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card deal()
    {
        if (cards.Count == 0) return null;
        Card cardToDeal = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        return cardToDeal;
    }

    public int getCount() => cards.Count;
}