using System.Globalization;
using System.Text;
using ClassLibrary;
using static ClassLibrary.ArrayAndLists;

Console.WriteLine("Hello, World!");

#region UtilityMethods
// TerrainMap();
// Traffic();
static string[] GetMonthNames()
{
    string[] names = new string[12];
    for (int i = 1; i <= 12; i++)
    {
        names[i - 1] = new DateTime(DateTime.Now.Year, i, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"));
    }
    return names;
}

static void Traffic()
{
    Random random = new Random();
    int transportTypesCount = Enum.GetNames(typeof(TransportEnum)).Length;
    TransportEnum[][] transport = new TransportEnum[12][];

    for (int month = 1; month <= 12; month++)
    {
        var daysCount = DateTime.DaysInMonth(DateTime.Now.Year, month);
        transport[month - 1] = new TransportEnum[daysCount];
        for (int day = 1; day <= daysCount; day++)
        {
            transport[month - 1][day - 1] = (TransportEnum)random.Next(transportTypesCount);
        }
    }

    var monthNames = GetMonthNames();

    int monthNameLength = monthNames.Max(n => n.Length);

    for (int month = 1; month <= transport.Length; month++)
    {
        Console.Write($"{monthNames[month-1]}".PadRight(monthNameLength + 4));
        for (int day = 1; day <= transport[month - 1].Length; day++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = transport[month - 1][day - 1].GetColor();
            Console.Write(transport[month - 1][day - 1].GetChar());
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("-");
        }
        Console.WriteLine();
    }
}

static void TerrainMap(TerrainEnum[,]? inMmap = null)
{
    TerrainEnum[,] map = inMmap ?? new TerrainEnum[,]
    {
        {TerrainEnum.SAND, TerrainEnum.SAND, TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.SAND},
        {TerrainEnum.GRASS, TerrainEnum.SAND, TerrainEnum.SAND,TerrainEnum.WATER,TerrainEnum.WATER,TerrainEnum.SAND},
        {TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER,TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.SAND},
        {TerrainEnum.WALL, TerrainEnum.SAND, TerrainEnum.WATER,TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.SAND},
        {TerrainEnum.SAND, TerrainEnum.SAND, TerrainEnum.WATER,TerrainEnum.WATER,TerrainEnum.WATER,TerrainEnum.WATER},
        {TerrainEnum.SAND, TerrainEnum.SAND, TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.SAND},
        {TerrainEnum.SAND, TerrainEnum.SAND, TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.SAND,TerrainEnum.SAND}
    };

    Console.OutputEncoding = UTF8Encoding.UTF8;
    for (int row = 0; row < map.GetLength(0); row++)
    {
        for (int column = 0; column < map.GetLength(1); column++)
        {
            Console.ForegroundColor = map[row, column].GetColor();
            Console.Write(map[row, column].GetChar());
        }
        Console.WriteLine();
    }

    Console.ForegroundColor = ConsoleColor.Gray;
    Console.ReadLine();
}
#endregion
