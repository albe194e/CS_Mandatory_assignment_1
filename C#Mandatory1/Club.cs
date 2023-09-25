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
}