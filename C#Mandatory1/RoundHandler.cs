using System.Drawing;
using System.Globalization;
using C_Mandatory1;
using CsvHelper;
using Microsoft.VisualBasic.FileIO;

public class RoundHandler {

    public Round ReadRound(string fileName) {

        Round round = new Round();

        try {
            using TextFieldParser parser = FileHandler.GetNewReader(fileName);

            // Read and parse the CSV file line by line
            while (!parser.EndOfData)
            {   
                if (parser.LineNumber == 1) {
                    //Will ignore the headers
                    parser.ReadFields();
                    continue;
                }
                var fields = parser.ReadFields();
                round.addMatch(fields[0], fields[1], fields[2]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return round;
    }

    public void WriteRound(string filePath, Round round)
    {
        Dictionary<string,Club> standings = new Dictionary<string,Club>();

        //Read standings data
        try {
            using TextFieldParser parser = FileHandler.GetNewReader(filePath);

            // Read and parse the CSV file line by line

            while (!parser.EndOfData)
            {
                if (parser.LineNumber == 1) {
                    //Will ignore the headers
                    parser.ReadFields();
                    continue;
                }

                var fields = parser.ReadFields();

                Club club = new Club(
                    int.Parse(fields[0]),
                    char.Parse(fields[1]),
                    fields[2],
                    int.Parse(fields[3]),
                    int.Parse(fields[4]),
                    int.Parse(fields[5]),
                    int.Parse(fields[6]),
                    int.Parse(fields[7]),
                    int.Parse(fields[8]),
                    fields[9]);

                
                Console.WriteLine("Club: " + club.GamesPlayed);
                standings.Add(club.Name, club);

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }


        Console.WriteLine(standings.Count);

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
                    standings[match.HomeTeam].GamesWon++;
                    standings[match.AwayTeam].GamesLost++;
                    break;
                case < 0:
                    standings[match.HomeTeam].GamesLost++;
                    standings[match.AwayTeam].GamesWon++;
                    break;
                case 0:
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

        StreamWriter writer = new StreamWriter(filePath + ".csv");
        CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

        List<Club> updatesStandings = new List<Club>();

        var clubs = standings.Keys;

        foreach (string club in clubs)
        {
            updatesStandings.Add(standings[club]);
        }
        csvWriter.WriteRecords(updatesStandings);

        csvWriter.Dispose();
        writer.Dispose();

    }
}