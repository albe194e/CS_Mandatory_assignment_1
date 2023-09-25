public class Round {

    public List<string> HomeTeams { get; set; }
    public List<string> AwayTeams { get; set; }
    public List<string> Results { get; set; }

    public Round() {
        HomeTeams = new List<string>();
        AwayTeams = new List<string>();
        Results = new List<string>();
    }

    public void addMatch(string homeTeam, string awayTeam, string result) {

        HomeTeams.Add(homeTeam);
        AwayTeams.Add(awayTeam);
        Results.Add(result);
    }
}