using System.Collections.Generic;

public class gameController
{
    private Deck deck;
    private Table table;
    private MoveValidator validator;

    public gameController()
    {
        deck = new Deck();
        table = new Table(deck);
        validator = new MoveValidator();
    }

    public Table getTable() => table;
    public int cardsRemaining() => deck.getCount();

    public bool makeMove(List<int> indexes)
    {
        List<Card> selected = new List<Card>();
        foreach (int i in indexes)
        {
            Card c = table.getCard(i);
            if (c != null) selected.Add(c);
        }

        if (validator.isValid(selected))
        {
            table.replaceCards(indexes);
            return true;
        }
        return false;
    }

    public bool isGameLost()
    {
        return validator.isGameOver(table.getBoard());
    }
}