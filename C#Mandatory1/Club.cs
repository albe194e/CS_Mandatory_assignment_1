namespace C_Mandatory1;

public class Club
{   

    public string Name { get; set; }
    public int GamesPlayed { get; set; }
    public int GamesWon { get; set; }
    public int GamesDrawn { get; set; }
    public int GamesLost { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference => GoalsFor - GoalsAgainst;
    public int Points => (GamesWon * 3) + GamesDrawn;
    public List<char> WinningStreak { get; set; }

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