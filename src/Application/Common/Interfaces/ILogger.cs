using MineSweeper.Domain.Entities;

namespace MineSweeper.Application.Common.Interfaces;
public interface ILogger
{
    void Log(Grid grid);
}
