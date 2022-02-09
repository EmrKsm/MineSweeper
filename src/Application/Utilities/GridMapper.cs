using MineSweeper.Domain.Entities;
using MineSweeper.Domain.Constants;
using System.Text;
using MineSweeper.Application.Common.Interfaces;

namespace MineSweeper.Application.Utilities;
public class GridMapper : IGridMapper
{
    public Grid MapArrayOfStringToGrid(string[] lines)
    {
        var grid = new Grid(lines.Length, lines[0].Length);

        int row = 0;

        foreach (var line in lines)
        {
            int column = 0;

            foreach (var symbol in line)
            {
                grid[new Location() { Row = row, Column = column }] = ParseSymbol(symbol);
                column++;
            }

            row++;
        }

        return grid;
    }

    public List<string> MapGridToArrayOfString(Grid grid)
    {
        var strings = new List<string>();

        for (int row = GridConstantValues.MinimumRow; row <= grid.MaxRows; row++)
        {
            var line = new StringBuilder();
            for (int column = GridConstantValues.MinimumColumn; column <= grid.MaxColumns; column++)
            {
                var symbol = ParseSymbol(grid[new Location() { Row = row, Column = column }]);
                line.Append(symbol);
            }

            strings.Add(line.ToString());
            line.Clear();
        }

        return strings;
    }

    private static int ParseSymbol(char symbol)
    {
        switch (symbol)
        {
            case SymbolConstantValues.Mine:
                return GridConstantValues.Mine;
            case SymbolConstantValues.Dot:
                return GridConstantValues.Zero;
            default:
                break;
        }

        return Convert.ToInt32(symbol);
    }

    private static char ParseSymbol(int number)
        => number == GridConstantValues.Mine ? SymbolConstantValues.Mine : char.Parse(number.ToString());
}
