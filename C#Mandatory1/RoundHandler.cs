using System.Globalization;
using C_Mandatory1;
using CsvHelper;
using Microsoft.VisualBasic.FileIO;

public class RoundHandler {


    public void ProcessRound(League league, Part part, int currentRound) {


        Round round = ReadRound(Path.rounds + league + "\\" + part + "\\round" + currentRound);

        switch (league) {
            case League.Super:
                WriteRound(Path.standings_super, round);
                break;
            case League.Nordic:
                WriteRound(Path.standings_nordic, round);
                break;
            default:
                break;
        }
    }

    public Round ReadRound(string fileName) {

        Round round = new Round();

        List<string[]> data = FileHandler.readFile(fileName);

        foreach (string[] line in data)
        {
            round.addMatch(line[0], line[1], line[2]);
        }

        return round;
    }

    public void WriteRound(string fileName, Round round)
    {   
        
        Dictionary<string,Club> standings = new Dictionary<string,Club>();

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

            standings.Add(club.Name, club);
        }
        

        //Update the data
        foreach (Match match in round.Matches)
        {
            string[] scoreStripped = match.Result.Split('-');
            int homeTeamScore = int.Parse(scoreStripped[0]);
            int awayTeamScore = int.Parse(scoreStripped[1]);

            //0 = tie, > 0 = home team win, < 0 away team win
            int result = homeTeamScore - awayTeamScore;
            switch (result) {

                case > 0:
                    UpdateStreak(standings[match.HomeTeam], 1);
                    UpdateStreak(standings[match.AwayTeam], -1);
                    standings[match.HomeTeam].GamesWon++;
                    standings[match.AwayTeam].GamesLost++;
                    break;
                case < 0:
                    UpdateStreak(standings[match.HomeTeam], -1);
                    UpdateStreak(standings[match.AwayTeam], 1);
                    standings[match.HomeTeam].GamesLost++;
                    standings[match.AwayTeam].GamesWon++;
                    break;
                case 0:
                    UpdateStreak(standings[match.HomeTeam], 0);
                    UpdateStreak(standings[match.AwayTeam], 0);
                    standings[match.HomeTeam].GamesDrawn++;
                    standings[match.AwayTeam].GamesDrawn++;
                    break;
                default:

            }
            standings[match.HomeTeam].GamesPlayed++;
            standings[match.HomeTeam].GoalsAgainst += awayTeamScore;
            standings[match.HomeTeam].GoalsFor += homeTeamScore;

            standings[match.AwayTeam].GamesPlayed++;
            standings[match.AwayTeam].GoalsAgainst += homeTeamScore;
            standings[match.AwayTeam].GoalsFor += awayTeamScore;
        }

        StreamWriter writer = new StreamWriter(fileName + ".csv");
        CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

        List<Club> updatedStandings = new List<Club>();

        var clubs = standings.Keys;

        foreach (string club in clubs)
        {
            updatedStandings.Add(standings[club]);
        }

        updatedStandings.Sort((x, y) => x.Points.CompareTo(y.Points));
        for (int i = 0; i < updatedStandings.Count; i++)
        {
            updatedStandings[i].Position = updatedStandings.Count - i;
        }

        csvWriter.WriteRecords(updatedStandings);

        csvWriter.Dispose();
        writer.Dispose();

    }

    private void UpdateStreak(Club club, int result) {
        
        //Result: 1 = win, -1 = loss, 0 = tie
        switch (club.WinningStreak)
        {

            case 0:
                club.WinningStreak = result;
                break;
            case > 0:
                club.WinningStreak = (club.WinningStreak < 0) ? result : club.WinningStreak++;
                break;
            case < 0:
                club.WinningStreak = (club.WinningStreak > 0) ? result : club.WinningStreak--;
                break;
        }
    }
}