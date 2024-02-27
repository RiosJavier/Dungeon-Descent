using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    public string PlayerId { get; set; }
    public int HighestLevelReached { get; set; }
}

public class LeaderboardManager
{
    private readonly Dictionary<string, Player> players = new Dictionary<string, Player>();

    // Updates the player's highest level reached, or adds the player if not already present
    public void UpdatePlayerLevel(string playerId, int level)
    {
        if (players.ContainsKey(playerId))
        {
            if (level > players[playerId].HighestLevelReached)
            {
                players[playerId].HighestLevelReached = level;
            }
        }
        else
        {
            players.Add(playerId, new Player { PlayerId = playerId, HighestLevelReached = level });
        }
    }

    // Retrieves the top N players based on the highest level reached
    public IEnumerable<Player> GetTopPlayers(int topN)
    {
        return players.Values.OrderByDescending(p => p.HighestLevelReached).Take(topN);
    }
}

class Program
{
    static void Main(string[] args)
    {
        LeaderboardManager leaderboard = new LeaderboardManager();

        leaderboard.UpdatePlayerLevel("player1", 5);
        leaderboard.UpdatePlayerLevel("player2", 3);
        leaderboard.UpdatePlayerLevel("player3", 8);
        leaderboard.UpdatePlayerLevel("player1", 10); // Update level for player1

        Console.WriteLine("Top players:");
        foreach (var player in leaderboard.GetTopPlayers(3))
        {
            Console.WriteLine($"Player ID: {player.PlayerId}, Highest Level: {player.HighestLevelReached}");
        }
    }
}
