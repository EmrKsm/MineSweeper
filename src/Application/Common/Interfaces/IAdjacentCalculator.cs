using MineSweeper.Domain.Entities;

namespace MineSweeper.Application.Common.Interfaces;

public interface IAdjacentCalculator
{
    void CalculateLeftAdjacent(Location mineLocation);
    void CalculateRightAdjacent(Location mineLocation);
    void CalculateUpperAdjacent(Location mineLocation);
    void CalculateBelowAdjacent(Location mineLocation);

    void CalculateBelowLeftAdjacent(Location mineLocation);
    void CalculateBelowRightAdjacent(Location mineLocation);
    void CalculateUpperLeftAdjacent(Location mineLocation);
    void CalculateUpperRightAdjacent(Location mineLocation);
}

