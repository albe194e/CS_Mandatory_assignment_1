using System.Globalization;
using C_Mandatory1;
using CsvHelper;

public class FileHandler {


    public Round ReadRound(string fileName) {

        using StreamReader reader = new StreamReader(fileName + ".csv");
        using CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var matches = csv.GetRecords<Match>();

        Round round = new Round();

        foreach (Match match in matches)
        {
            round.addMatch(match.HomeTeam, match.AwayTeam, match.Result);
        }

        return round;
    }
}