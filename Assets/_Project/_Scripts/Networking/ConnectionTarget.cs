namespace Project.Assets._Project._Scripts.Networking
{
    // A join target as one string, "address", "address:port" or "[ipv6]:port", so a listed lobby's port survives the trip through the menu
    public static class ConnectionTarget
    {
        private const char PortSeparator = ':';
        private const char IPv6Open = '[';
        private const char IPv6Close = ']';

        public static string Format(string address, ushort port) =>
            address.IndexOf(PortSeparator) >= 0 ? $"{IPv6Open}{address}{IPv6Close}{PortSeparator}{port}" : $"{address}{PortSeparator}{port}";

        // Blank falls back to the defaults; a missing port uses the default one. False for a port that isn't a number in range.
        public static bool TryParse(string target, string defaultAddress, ushort defaultPort, out string address, out ushort port)
        {
            address = defaultAddress;
            port = defaultPort;
            if (string.IsNullOrWhiteSpace(target)) return true;

            var trimmed = target.Trim();
            int separatorIndex = trimmed.LastIndexOf(PortSeparator);
            bool isBracketed = trimmed[0] == IPv6Open;
            // a bare IPv6 address has several separators and no port
            bool isBareIPv6 = !isBracketed && separatorIndex != trimmed.IndexOf(PortSeparator);
            if (isBracketed)
            {
                int closeIndex = trimmed.IndexOf(IPv6Close);
                if (closeIndex < 0) return false;
                if (closeIndex == trimmed.Length - 1)
                {
                    address = trimmed.Substring(1, closeIndex - 1);
                    return true;
                }
                if (separatorIndex != closeIndex + 1) return false;
            }
            else if (separatorIndex < 0 || isBareIPv6)
            {
                address = trimmed;
                return true;
            }

            var addressPart = isBracketed ? trimmed.Substring(1, separatorIndex - 2) : trimmed.Substring(0, separatorIndex).Trim();
            var portPart = trimmed.Substring(separatorIndex + 1).Trim();
            if (!ushort.TryParse(portPart, out var parsedPort) || parsedPort == 0) return false;

            address = addressPart.Length == 0 ? defaultAddress : addressPart;
            port = parsedPort;
            return true;
        }
    }
}
