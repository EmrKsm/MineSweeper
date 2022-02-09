using MineSweeper.Application.Common.Interfaces;
using MineSweeper.Domain.Constants;
using MineSweeper.Domain.Entities;

namespace MineSweeper.Application.Services;

public class MineSweeperService : IMineSweeperService
{
    private readonly IAdjacentCalculator _adjacentCalculator;

    public MineSweeperService(IAdjacentCalculator adjacentCalculator)
    {
        _adjacentCalculator = adjacentCalculator;
    }

    public void CalculateAdjacentValues(Grid grid)
    {
        for (int row = 0; row <= grid.MaxRows; row++)
        {
            for (int column = 0; column <= grid.MaxColumns; column++)
            {
                Location location = new() { Row = row, Column = column };
                if (grid[location] == GridConstantValues.Mine)
                    CalculateAdjacents(location);
            }
        }
    }

    private void CalculateAdjacents(Location location)
    {
        _adjacentCalculator.CalculateBelowAdjacent(location);
        _adjacentCalculator.CalculateUpperAdjacent(location);
        _adjacentCalculator.CalculateLeftAdjacent(location);
        _adjacentCalculator.CalculateRightAdjacent(location);
        _adjacentCalculator.CalculateUpperLeftAdjacent(location);
        _adjacentCalculator.CalculateUpperRightAdjacent(location);
        _adjacentCalculator.CalculateBelowLeftAdjacent(location);
        _adjacentCalculator.CalculateBelowRightAdjacent(location);
    }
}

