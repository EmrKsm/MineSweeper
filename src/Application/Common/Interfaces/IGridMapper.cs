using MineSweeper.Domain.Entities;

namespace MineSweeper.Application.Common.Interfaces;

public interface IGridMapper
{
    Grid MapArrayOfStringToGrid(string[] lines);

    List<string> MapGridToArrayOfString(Grid grid);
}