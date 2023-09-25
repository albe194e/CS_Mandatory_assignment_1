namespace C_Mandatory1;

public class Club
{
    public int Position {get; set;}
    public char SpecialRanking {get; set;}
    public string Name { get; set; }
    public int GamesPlayed { get; set; }
    public int GamesWon { get; set; }
    public int GamesDrawn { get; set; }
    public int GamesLost { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference => GoalsFor - GoalsAgainst;
    public int Points => (GamesWon * 3) + GamesDrawn;
    public string WinningStreak { get; set; }

    public Club(int position, char specialRanking, string name, int gamesPlayed, int gamesWon, int gamesDrawn, int gamesLost, int goalsFor, int goalsAgainst, string winningStreak)
    {
        Position = position;
        SpecialRanking = specialRanking;
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