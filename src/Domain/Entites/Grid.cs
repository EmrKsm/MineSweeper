using MineSweeper.Domain.Constants;

namespace MineSweeper.Domain.Entities;
public class Grid : IGrid
{
    private readonly int[,] _gridCells;
    private readonly int _maxRows;
    private readonly int _maxColumns;

    public int MaxRows => _maxRows - 1;
    public int MaxColumns => _maxColumns - 1;

    public Grid(int maxRows, int maxColumns)
    {
        _maxRows = maxRows;
        _maxColumns = maxColumns;
        _gridCells = new int[maxRows, maxColumns];
    }

    public int this[Location cellLocation]
    {
        get => _gridCells[cellLocation.Row, cellLocation.Column];
        set => _gridCells[cellLocation.Row, cellLocation.Column] = value;
    }

    public void IncrementCellValue(Location location)
    {
        var currentValue = this[location];

        if (currentValue == GridConstantValues.Mine)
            return;

        this[location] = currentValue + 1;
    }

}