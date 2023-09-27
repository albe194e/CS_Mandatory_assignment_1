

using C_Mandatory1;
using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using System.Globalization;

public class Standings {

    public void Reset(League league)
    {   
        string filepath = (league == League.Super) ? Path.standings_super : Path.standings_nordic;

        List<Club> defaultStandings = new List<Club>();
        
        List<string[]> data = FileHandler.readFile(filepath);

        foreach (string[] line in data)
        {
            Club club = new Club(line[2]);
            defaultStandings.Add(club);
        }

        StreamWriter writer = new StreamWriter(filepath + ".csv");
        CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(defaultStandings);

        csvWriter.Dispose();
        writer.Dispose();

    }

    public List<Club> SortBy(List<Club> clubs, Sort sort) {

    
        switch (sort)
        {
            case Sort.position:
                clubs.Sort((x, y) => x.Position.CompareTo(y.Position));
                break;
            case Sort.gamesWon:
                clubs.Sort((x, y) => y.GamesWon.CompareTo(x.GamesWon));
                break;
            case Sort.goalsFor:
                clubs.Sort((x, y) => y.GoalsFor.CompareTo(x.GoalsFor));
                break;
            default:
                break;
        }

        return clubs;
    }

    public void DisplayBy(League league, Sort sort)
    {   
        List<Club> clubs = new List<Club>();

        string fileName = (league == League.Super) ? Path.standings_super : Path.standings_nordic;

        //Read standings data
        List<string[]> data = FileHandler.readFile(fileName);

        foreach (string[] line in data)
        {
            Club club = new Club(
            int.Parse(line[0]),
            char.Parse(line[1]),
            line[2],
            int.Parse(line[3]),
            int.Parse(line[4]),
            int.Parse(line[5]),
            int.Parse(line[6]),
            int.Parse(line[7]),
            int.Parse(line[8]),
            int.Parse(line[9]));

            clubs.Add(club);
        }

        clubs = SortBy(clubs, sort);

        string headers = $"{league.ToString().ToUpper()}\n" + 
                         $"{"Pos",-4}       {"Team",-30} " +
                         $"{"M",-4} {"W",-4} {"D",-4} " +
                         $"{"L",-4} {"GF",-4} {"GA",-4} " +
                         $"{"GD",-4} {"P",-4} {"Streak"}";
        Console.WriteLine(headers);
        foreach (Club club in clubs)
        {
            string streak = club.WinningStreak.ToString();
            streak = string.IsNullOrEmpty(streak) ? "-" : streak;

            string line = $"{club.Position,-4}       {club.Name,-30} " +
                          $"{club.GamesPlayed,-4} {club.GamesWon,-4} {club.GamesDrawn,-4} " +
                          $"{club.GamesLost,-4} {club.GoalsFor,-4} {club.GoalsAgainst,-4} " +
                          $"{club.GoalDifference,-4} {club.Points,-4} {streak}";

            Console.WriteLine(line);
        }
    }
}