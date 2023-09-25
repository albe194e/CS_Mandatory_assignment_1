using System.Globalization;
using C_Mandatory1;
using CsvHelper;
using CsvHelper.Configuration;

public class FileHandler {

    private CsvConfiguration confiq = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = false,
        TrimOptions = TrimOptions.Trim,
        MissingFieldFound = null,
        HeaderValidated = null
    };


    public Round ReadRound(string fileName) {

        using StreamReader reader = new StreamReader(fileName + ".csv");
        using CsvReader csv = new CsvReader(reader, confiq);
        var matches = csv.GetRecords<Match>();

        csv.Read();

        Round round = new Round();

        foreach (Match match in matches)
        {
            Console.WriteLine(match.ToString());
            round.addMatch(match.HomeTeam, match.AwayTeam, match.Result);
        }

        return round;
    }
}