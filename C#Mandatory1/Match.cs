using CsvHelper.Configuration.Attributes;

public class Match {

    [Name("Home Team")]
    public string HomeTeam { get; set; }
    [Name("Away Team")]
    public string AwayTeam { get; set; }
    [Name("Score")]
    public string Result { get; set; }

    public Match(string homeTeam, string awayTeam, string result) {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        Result = result;
    }
}