using System.Globalization;
using System.Text;
using System.Transactions;
using ClassLibrary;
using DSAClassLib;
using static ClassLibrary.ArrayAndLists;
namespace ConsoleApp
{
    public class Program
    {
        const int disk_count = 10;
        const int delay = 250;
        static int _columnSize = Math.Max(6, GetDiscWidth(disk_count) + 2);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Sort();
            // TerrainMap();
            // Traffic();
            // Wheel();
            // Console.WriteLine(DsaStack.StackReverse("LET'S REVERSE IT!"));
            SolveHanoiTower();
        }

        public static void SolveHanoiTower()
        {
            var algorithm = new HanoiTower(disk_count);
            algorithm.MovesCompleted += Algorithm_Visualize;
            Algorithm_Visualize(algorithm, EventArgs.Empty);
            algorithm.Start();
        }
        private static int GetDiscWidth(int size)
        {
            return size * 2 - 1;
        }

        private static void Algorithm_Visualize(object sender, EventArgs e)   
        {
            Console.Clear();
            var algorithm = (HanoiTower)sender;
            if (algorithm.DiscsCount <= 0)
            {
                return;
            }
            char[][] visualization = InitializeVisualization(algorithm);
            PrepareColumn(visualization, 1, algorithm.DiscsCount, algorithm.From);
            PrepareColumn(visualization, 2, algorithm.DiscsCount, algorithm.To);
            PrepareColumn(visualization, 3, algorithm.DiscsCount, algorithm.Aux);

            Console.WriteLine(Center("FROM") + Center("TO") + Center("AUX"));
            DrawVisualization(visualization);
            Console.WriteLine();
            Console.WriteLine($"Number of moves: {algorithm.MovesCount}");
            Console.WriteLine($"Number of discs: {algorithm.DiscsCount}");

            Thread.Sleep(delay);
        }

        private static string? Center(string txt)
        {
            int margin = (_columnSize - txt.Length) / 2;
            return txt.PadLeft(margin + txt.Length).PadRight(_columnSize);
        }

        private static void DrawVisualization(char[][] visualization)
        {
            for(int y = 0; y < visualization.Length; y++)
            {
                Console.WriteLine(visualization[y]);
            }
        }

        private static void PrepareColumn(char[][] visualization, int column, int discsCount, Stack<int> stack)
        {
            int margin = _columnSize * (column - 1);

            for (int y = 0; y < stack.Count; y++)
            {
                int size = stack.ElementAt(y);
                int row = discsCount - (stack.Count - y);
                int columnStart = margin + discsCount - size;
                int columnEnd = columnStart + GetDiscWidth(size);
                
                for(int x = columnStart; x <= columnEnd; x++)
                {
                    visualization[row][x] = '=';
                }
            }
        }

        private static char[][] InitializeVisualization(HanoiTower algorithm)
        {
            char[][] visualization = new char[algorithm.DiscsCount][];
            for (int y = 0; y < visualization.Length; y++)
            {
                visualization[y] = new char[_columnSize * 3];
                for (int x = 0; x < _columnSize * 3; x++ )
                {
                    visualization[y][x] = ' ';
                }
            }
            return visualization;
        }

        #region UtilityMethods
        static void Wheel()
        {
            var categories = new CircularLinkedList<string>();
            categories.AddLast("Sport");
            categories.AddLast("Culture");
            categories.AddLast("History");
            categories.AddLast("Geography");
            categories.AddLast("People");
            categories.AddLast("Technology");
            categories.AddLast("Nature");
            categories.AddLast("Science");

            Random random = new Random();
            int totalTime = 0;
            int remainingTime = 0;

            foreach (string category in categories)
            {
                if (remainingTime <= 0)
                {
                    Console.WriteLine("Press [Enter] to start or any other to exit");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            totalTime = random.Next(1000, 5000);
                            remainingTime = totalTime;
                            break;
                        default:
                            return;
                    }
                }
                int categoryTime = -450 * remainingTime / (totalTime - 50) + 500 + (22500 / (totalTime - 50));
                remainingTime -= categoryTime; // <= 0 ? 20 : categoryTime ;
                Thread.Sleep(categoryTime);

                Console.ForegroundColor = remainingTime <= 0 ? ConsoleColor.Red : ConsoleColor.Green;
                Console.WriteLine(category);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

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
            Console.Write($"{monthNames[month - 1]}".PadRight(monthNameLength + 4));
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

    static void Sort()
    {
        var nums = new int[] { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
        var str = new string[] { "Bet", "Don", "Mary", "Ann" };
        // -42, -11, -9, 0, 1, 6, 12, 68, 90 
        // DsaSolution.SelectionSort(nums);
        // DsaSolution.InsertionSort(nums);
        DsaSolution.QuickSort(nums);
        Console.WriteLine(string.Join(" | ", nums));
        Console.ReadLine();
        // DsaSolution.SelectionSort(nums);
        // DsaSolution.InsertionSort(str);
        DsaSolution.QuickSort(str);
        Console.WriteLine(string.Join(" | ", str));
        Console.ReadLine();
    }
    #endregion
    }
}

