using CsvHelper.Configuration.Attributes;

public class Match {

    public string HomeTeam { get; set; }
    public string AwayTeam { get; set; }
    public string Result { get; set; }

    public Match(string homeTeam, string awayTeam, string result) {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        Result = result;
    }
}