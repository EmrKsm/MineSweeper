using MineSweeper.Application.Common.Interfaces;
using MineSweeper.Domain.Entities;

namespace MineSweeper.Application.Utilities;
public class ConsoleLogger : ILogger
{
    private readonly IGridMapper _gridPanelMapper;

    public ConsoleLogger(IGridMapper gridPanelMapper)
    {
        _gridPanelMapper = gridPanelMapper;
    }

    public void Log(Grid grid)
    {
        var strings = _gridPanelMapper.MapGridToArrayOfString(grid);

        foreach (var line in strings)
        {
            Console.WriteLine(line);
        }
    }
}

