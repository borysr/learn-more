
using static ClassLibrary.ArrayAndLists;
public static class TransportEnumExtensions
{
    public static ConsoleColor GetColor(this TransportEnum transport)
    {
        switch (transport)
        {
            case TransportEnum.CAR: return ConsoleColor.Red;
            case TransportEnum.BIKE: return ConsoleColor.Green;
            case TransportEnum.BUS: return ConsoleColor.Blue;
            case TransportEnum.SUBWAY: return ConsoleColor.Yellow;
            case TransportEnum.WALK: return ConsoleColor.White;
            default: return ConsoleColor.DarkGray;
        }
    }
    public static char GetChar(this TransportEnum transport)
    {
        switch (transport)
        {
            case TransportEnum.CAR: return 'C';
            case TransportEnum.BIKE: return 'B';
            case TransportEnum.BUS: return 'U';
            case TransportEnum.SUBWAY: return 'S';
            case TransportEnum.WALK: return 'W';
            default: return '\u25cf';
        }
    }
}