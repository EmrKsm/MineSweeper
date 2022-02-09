namespace MineSweeper.Domain.Entities;

public interface IGrid
{
    void IncrementCellValue(Location location);
}