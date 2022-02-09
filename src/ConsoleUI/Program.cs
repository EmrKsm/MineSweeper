using MineSweeper.Application.Services;
using MineSweeper.Application.Utilities;
using MineSweeper.Domain.Entities;

string path = Path.Combine(
    Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.FullName,
    "resources" );

foreach(var file in  Directory.GetFiles(path))
{
    var gridMapper = new GridMapper();
    var grid = LoadGrid(file, gridMapper);

    var mineSweeperService = new MineSweeperService(new AdjacentCalculator(grid));
    mineSweeperService.CalculateAdjacentValues(grid);

    LogGridToConsole(gridMapper, grid);

    Console.WriteLine();
}

static void LogGridToConsole(GridMapper gridMapper, Grid grid)
{
    var logger = new ConsoleLogger(gridMapper);
    logger.Log(grid);
}

static Grid LoadGrid(string inputPath, GridMapper mapper)
{
    var gridLoader = new TextFileToGridLoader(inputPath, mapper);
    return gridLoader.LoadGrid();
}