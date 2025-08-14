// See https://aka.ms/new-console-template for more information
using System.Text;
using ClassLibrary;
using static ClassLibrary.ArrayAndLists;

Console.WriteLine("Hello, World!");
TerrainEnum[,] map =
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
