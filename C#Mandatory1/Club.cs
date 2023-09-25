namespace C_Mandatory1;

public class Club
{
    private string Name { get; set; }
    private int GamesPlayed { get; set; }
    private int GamesWon { get; set; }
    private int GamesDrawn { get; set; }
    private int GamesLost { get; set; }
    private int GoalsFor { get; set; }
    private int GoalsAgainst { get; set; }
    private int GoalDifference => GoalsFor - GoalsAgainst;
    private int Points => (GamesWon * 3) + GamesDrawn;
    private List<char> WinningStreak { get; set; }

    public Club(string name, int gamesPlayed, int gamesWon, int gamesDrawn, int gamesLost, int goalsFor, int goalsAgainst, List<char> winningStreak)
    {
        Name = name;
        GamesPlayed = gamesPlayed;
        GamesWon = gamesWon;
        GamesDrawn = gamesDrawn;
        GamesLost = gamesLost;
        GoalsFor = goalsFor;
        GoalsAgainst = goalsAgainst;
        WinningStreak = winningStreak;
    }
}