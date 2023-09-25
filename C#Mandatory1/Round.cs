public class Round {

    public List<Match> Matches { get; set; }

    public Round() {
        Matches = new List<Match>();

    }

    public void addMatch(string homeTeam, string awayTeam, string result) {

        Matches.Add(new Match(homeTeam, awayTeam, result));
    }
}