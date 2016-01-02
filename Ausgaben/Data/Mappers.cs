namespace Ausgaben.Data
{
    using System;

    internal static class Mappers
    {
        public static Guid ToGuid(string input)
        {
            var guid = Guid.Empty;
            Guid.TryParse(input, out guid);
            return guid;
        }
    }
}