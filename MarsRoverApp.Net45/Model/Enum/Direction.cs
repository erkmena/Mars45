using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Model.Enums
{
    /// <summary>
    /// Main Directions. Struct because theese values don't changes generally.
    /// </summary>
    public struct Direction
    {
        public const char North = 'N';
        public const char South = 'S';
        public const char East = 'E';
        public const char West = 'W';
    }
}
