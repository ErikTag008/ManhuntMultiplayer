using System;
using System.Collections.Generic;
using System.Globalization;

namespace Project.Assets._Project._Scripts.Networking
{
    // A Steam lobby as a join target: its id in decimal, as Steam writes it after +connect_lobby on the command line
    public static class SteamLobbyId
    {
        private const string ConnectLobbyArg = "+connect_lobby";

        public static string Format(ulong lobbyId) => lobbyId.ToString(CultureInfo.InvariantCulture);

        public static bool TryParse(string text, out ulong lobbyId)
        {
            lobbyId = 0;
            if (string.IsNullOrWhiteSpace(text)) return false;

            return ulong.TryParse(text.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out lobbyId) && lobbyId != 0;
        }

        // Steam launches the game with "+connect_lobby <id>" when a friend accepts an invite while it isn't running
        public static bool TryFindInLaunchArgs(IReadOnlyList<string> args, out ulong lobbyId)
        {
            lobbyId = 0;
            if (args == null) return false;

            for (int i = 0; i < args.Count - 1; i++)
            {
                if (string.Equals(args[i], ConnectLobbyArg, StringComparison.OrdinalIgnoreCase)) return TryParse(args[i + 1], out lobbyId);
            }

            return false;
        }
    }
}
