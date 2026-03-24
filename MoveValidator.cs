public class MoveValidator
{
    public bool isValid(List<Card> selectedCards)
    {
        if (selectedCards.Count == 2)
        {
            return (selectedCards[0].getValue() + selectedCards[1].getValue() == 11);
        }
        
        if (selectedCards.Count == 3)
        {
            bool hasJ = false, hasQ = false, hasK = false;
            foreach (var c in selectedCards)
            {
                if (c.getValue() == 11) hasJ = true;
                if (c.getValue() == 12) hasQ = true;
                if (c.getValue() == 13) hasK = true;
            }
            return hasJ && hasQ && hasK;
        }
        return false;
    }


    //no logic to end the game besides quit

    public bool isGameOver(List<Card> board)
    {
        for (int i = 0; i < board.Count; i++)
        {
            for (int j = i + 1; j < board.Count; j++)
            {
                if (board[i] != null && board[j] != null)
                {
                    if (board[i].getValue() + board[j].getValue() == 11) return false; 
                }
            }
        }

        bool hasJ = false, hasQ = false, hasK = false;
        foreach (Card c in board)
        {
            if (c != null)
            {
                if (c.getValue() == 11) hasJ = true;
                if (c.getValue() == 12) hasQ = true;
                if (c.getValue() == 13) hasK = true;
            }
        }
        
        if (hasJ && hasQ && hasK) return false;

        return true;
    }
}