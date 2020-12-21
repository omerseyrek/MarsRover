
using System.ComponentModel;

namespace MarsRoverLib
{
    public enum Direction : int
    {
        [Description("X")]
        None,
        
        [Description("N")]
        North,

        [Description("E")]
        East,

        [Description("S")]
        South,

         [Description("W")]
        West
    }

    public enum TurnSide : int
    {
        Left,
        Right
    }
}
