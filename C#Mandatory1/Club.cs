﻿namespace C_Mandatory1;

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
    public int WinningStreak { get; set; }

    public Club(int position, char specialRanking, string name, int gamesPlayed, int gamesWon, int gamesDrawn, int gamesLost, int goalsFor, int goalsAgainst, int winningStreak)
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

    public Club(string name) {
            Position = 0;
            SpecialRanking = '_';
            Name = name;
            GamesPlayed = 0;
            GamesWon = 0;
            GamesDrawn = 0;
            GamesLost = 0;
            GoalsFor = 0;
            GoalsAgainst = 0;
            WinningStreak = 0;
    }


    public override string ToString() {

        return "\nClub: " + Name +
               "\nPos : " + Position +
               "\nGamesPlayed: " + GamesPlayed +
               "\nGamesWon: " + GamesWon +
               "\nGamesDrawn: " + GamesDrawn +
               "\nGamesLost: " + GamesLost +
               "\nGoalsFor: " + GoalsFor +
               "\nGoalsAgains: " + GoalsAgainst +
               "\nStreak: " + WinningStreak;
    }
}