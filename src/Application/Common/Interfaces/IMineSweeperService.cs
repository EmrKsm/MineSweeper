using MineSweeper.Domain.Entities;

namespace MineSweeper.Application.Common.Interfaces;

public interface IMineSweeperService
{
    void CalculateAdjacentValues(Grid grid);
}

