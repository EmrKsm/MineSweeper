using MineSweeper.Application.Common.Interfaces;
using MineSweeper.Domain.Constants;
using MineSweeper.Domain.Entities;

namespace MineSweeper.Application.Services;

public class AdjacentCalculator : IAdjacentCalculator
{
    private readonly Grid _grid;
    public AdjacentCalculator(Grid grid)
    {
        _grid = grid;
    }
    public void CalculateBelowAdjacent(Location mineLocation)
    {
        if (mineLocation.Row >= _grid.MaxRows)
            return;

        _grid.IncrementCellValue(
            new Location 
            { 
                Row = GetBelowRowIndex(mineLocation.Row), 
                Column = mineLocation.Column 
            });
    }
    public void CalculateUpperAdjacent(Location mineLocation)
    {
        if (mineLocation.Row <= GridConstantValues.MinimumRow)
            return;

        _grid.IncrementCellValue(
           new Location
           {
               Row = GetUpperRowIndex(mineLocation.Row),
               Column = mineLocation.Column
           });
    }

    public void CalculateLeftAdjacent(Location mineLocation)
    {
        if (mineLocation.Column <= GridConstantValues.MinimumColumn)
            return;

        _grid.IncrementCellValue(
            new Location
            {
                Row = mineLocation.Row,
                Column = GetLeftColumnIndex(mineLocation.Column)
            });
    }

    public void CalculateRightAdjacent(Location mineLocation)
    {
        if (mineLocation.Column >= _grid.MaxColumns)
            return;

        _grid.IncrementCellValue(
            new Location
            {
                Row = mineLocation.Row,
                Column = GetRightColumnIndex(mineLocation.Column)
            });
    }

    public void CalculateBelowLeftAdjacent(Location mineLocation)
    {
        if(mineLocation.Row < _grid.MaxRows && mineLocation.Column > GridConstantValues.MinimumColumn)
            _grid.IncrementCellValue(
                new Location
                {
                    Row = GetBelowRowIndex(mineLocation.Row),
                    Column = GetLeftColumnIndex(mineLocation.Column)
                });
    }

    public void CalculateBelowRightAdjacent(Location mineLocation)
    {
        if(mineLocation.Row < _grid.MaxRows && mineLocation.Column < _grid.MaxColumns)
            _grid.IncrementCellValue(
                new Location
                {
                    Row = GetBelowRowIndex(mineLocation.Row),
                    Column = GetRightColumnIndex(mineLocation.Column)
                });
    }

    public void CalculateUpperLeftAdjacent(Location mineLocation)
    {
        if(mineLocation.Row > GridConstantValues.MinimumRow && mineLocation.Column > GridConstantValues.MinimumColumn)
            _grid.IncrementCellValue(
                new Location
                {
                    Row = GetUpperRowIndex(mineLocation.Row),
                    Column = GetLeftColumnIndex(mineLocation.Column)
                });
    }

    public void CalculateUpperRightAdjacent(Location mineLocation)
    {
        if (mineLocation.Row > GridConstantValues.MinimumRow && mineLocation.Column < _grid.MaxColumns)
            _grid.IncrementCellValue(
                new Location
                {
                    Row = GetUpperRowIndex(mineLocation.Row),
                    Column = GetRightColumnIndex(mineLocation.Column)
                });
    }

    private static int GetUpperRowIndex(int row) => --row;
    private static int GetBelowRowIndex(int row) => ++row;
    private static int GetRightColumnIndex(int column) => ++column;
    private static int GetLeftColumnIndex(int column) => --column;
}

