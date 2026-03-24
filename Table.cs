using System.Collections.Generic;

public class Table
{
    private List<Card> cardsOnTable = new List<Card>();
    private Deck deck;

    public Table(Deck deck)
    {
        this.deck = deck;
        for (int i = 0; i < 9; i++) cardsOnTable.Add(deck.deal());
    }

    public Card getCard(int index) => (index >= 0 && index < 9) ? cardsOnTable[index] : null;

    public void replaceCards(List<int> indexes)
    {
        foreach (int i in indexes)
        {
            cardsOnTable[i] = deck.deal();
        }
    }

    public List<Card> getBoard() => cardsOnTable;
}