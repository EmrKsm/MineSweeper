using MineSweeper.Application.Common.Interfaces;
using MineSweeper.Domain.Entities;

namespace MineSweeper.Application.Utilities;
public class TextFileToGridLoader : IGridLoader
{
    private readonly string _path;
    private readonly IGridMapper _gridMapper;

    public TextFileToGridLoader(string path, IGridMapper gridMapper)
    {
        _path = path;
        _gridMapper = gridMapper;
    }
    public Grid LoadGrid()
    {
        var lines = File.ReadAllLines(_path);

        return _gridMapper.MapArrayOfStringToGrid(lines);
    }
}

