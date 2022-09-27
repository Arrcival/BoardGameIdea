using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameIdea.Entities;

public static class Helper
{
    public enum TileType { EMPTY, WHITE, BLACK };
    public static ParallelOptions ParallelOptions = new ParallelOptions()
    {
        MaxDegreeOfParallelism = 5
    };
}
