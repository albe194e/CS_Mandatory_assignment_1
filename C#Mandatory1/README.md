How the program works:

    The program has a Main method that initializes the leagues and the number of rounds in each part of the season. It then loops through each round of each league and calls the ProcessRound method to update the standings. Finally, it calls the DisplayStandings method to display the final standings of the teams in each league.

    The ProcessRound method takes in the league, part, and current round number as parameters. It reads in the round of matches from a file and updates the standings of the teams in the league.

    The DisplayStandings method takes in a list of clubs and displays the final standings of the teams in the league. It prints out the position, name, games played, games won, games drawn, games lost, goals for, goals against, goal difference, points, and winning streak of each team.


What we got done:
    We made the first split, and showed a table with the teams in the league, and their stats. 


What we didn't get done:
    Trouble showing the winning streak of each team in the league.
    We didnd't get to make the second split.

What we have used:

    To read from csv: TextFieldParser
    To write to csv: CsvHelper
    We had trouble reading a csv file with CsvHelper