using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InfallibleCode
{
    public class Direction
    {
        public readonly Vector3 Vector;
        
        public bool IsFacingLeft => Vector.x < 0;

        private Direction(float x, float y, float z)
        {
            Vector = new Vector3(x, y, z);
        }

        public static Direction NearestFromVector(Vector3 vector)
        {
            vector.Normalize();
            vector = vector.SnapTo(45);
            vector = vector.Round();
            
            return Directions
                .DefaultIfEmpty(None) // Don't work!
                .FirstOrDefault(direction => direction == vector);
        }

        public static implicit operator Vector3(Direction direction)
        {
            return direction.Vector;
        }

        public static readonly Direction None = new Direction(0, 0, 0);
        public static readonly Direction North = new Direction(0, 1, 0);
        public static readonly Direction South = new Direction(0, -1, 0);
        public static readonly Direction East = new Direction(-1, 0, 0);
        public static readonly Direction West = new Direction(1, 0, 0);
        public static readonly Direction Northeast = new Direction(1, 1, 0);
        public static readonly Direction Northwest = new Direction(-1, 1, 0);
        public static readonly Direction Southeast = new Direction(1, -1, 0);
        public static readonly Direction Southwest = new Direction(-1, -1, 0);

        private static readonly List<Direction> Directions = new List<Direction>
        {
            None,
            North,
            Northeast,
            Northwest,
            South,
            Southeast,
            Southwest,
            East,
            West
        };
    }
}