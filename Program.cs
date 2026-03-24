// this was written by AI in order to run the game.

gameController game = new gameController();

while (true)
{
    Console.Clear();

    List<Card> board = game.getTable().getBoard();
    for (int i = 0; i < board.Count; i++)
    {
        string s = (board[i] == null) ? "EMPTY" : board[i].ToString();
        Console.WriteLine($"[{i}] {s}");
    }

    if (game.isGameLost())
    {
        Console.WriteLine("\n--- GAME OVER: No more legal moves! ---");
        break;
    }

    Console.WriteLine($"\nDeck: {game.cardsRemaining()} cards left.");
    Console.Write("Enter indexes (for 11 pair or J Q K) or q to quit: ");

    string input = Console.ReadLine();
    if (input == null) continue;

    if (input.Trim().ToLower() == "q") break;

    string[] tokens = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
    List<int> indexes = new List<int>();
    foreach (string t in tokens)
    {
        if (int.TryParse(t, out int value) && value >= 0 && value < board.Count)
        {
            indexes.Add(value);
        }
    }

    if (indexes.Count == 0)
    {
        Console.WriteLine("No valid indexes entered. Press any key to continue");
        Console.ReadKey();
        continue;
    }

    if (game.makeMove(indexes))
    {
        Console.WriteLine("Move accepted.");
    }
    else
    {
        Console.WriteLine("Invalid move. You must select two cards summing to 11 or J/Q/K. Press any key to continue");
        Console.ReadKey();
    }
}
