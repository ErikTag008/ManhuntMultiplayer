using System;
using System.Collections.Generic;
using System.Globalization;

namespace Project.Assets._Project._Scripts.Networking
{
    // A Steam lobby as a join target: its id in decimal (as Steam writes it after +connect_lobby on the command line)
    // or as a join code, the same id in Crockford base-32 padded to CodeLength characters
    public static class SteamLobbyId
    {
        public const int CodeLength = 13;

        private const string ConnectLobbyArg = "+connect_lobby";
        private const string CodeAlphabet = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
        private const int BitsPerCodeCharacter = 5;
        private const ulong CodeCharacterMask = 31;
        // 13 characters hold 65 bits, so the first one may only use the lowest 4
        private const int FirstCodeCharacterLimit = 16;

        public static string Format(ulong lobbyId) => lobbyId.ToString(CultureInfo.InvariantCulture);

        public static string FormatCode(ulong lobbyId)
        {
            var characters = new char[CodeLength];
            for (int i = CodeLength - 1; i >= 0; i--)
            {
                characters[i] = CodeAlphabet[(int)(lobbyId & CodeCharacterMask)];
                lobbyId >>= BitsPerCodeCharacter;
            }

            return new string(characters);
        }

        // a decimal id or a join code; codes ignore case and read I/L as 1 and O as 0
        public static bool TryParse(string text, out ulong lobbyId)
        {
            lobbyId = 0;
            if (string.IsNullOrWhiteSpace(text)) return false;

            var trimmed = text.Trim();
            // real lobby ids have about 18 decimal digits, so a 13-character text is always a code
            if (trimmed.Length == CodeLength && TryParseCode(trimmed, out lobbyId)) return lobbyId != 0;

            return ulong.TryParse(trimmed, NumberStyles.None, CultureInfo.InvariantCulture, out lobbyId) && lobbyId != 0;
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

        private static bool TryParseCode(string code, out ulong lobbyId)
        {
            lobbyId = 0;
            for (int i = 0; i < code.Length; i++)
            {
                int value = GetCodeValue(code[i]);
                if (value < 0) return false;
                if (i == 0 && value >= FirstCodeCharacterLimit) return false;

                lobbyId = (lobbyId << BitsPerCodeCharacter) | (ulong)value;
            }

            return true;
        }

        private static int GetCodeValue(char character)
        {
            char upper = char.ToUpperInvariant(character);
            return upper switch
            {
                'I' or 'L' => 1,
                'O' => 0,
                _ => CodeAlphabet.IndexOf(upper)
            };
        }
    }
}
