namespace OutrageEngine.Vector
{
    /// <summary>
    /// Custom Vector allows control of characteristics
    /// </summary>
    public struct Vector
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Add two vectors
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>A new vector whose X and Y are each the sum of that of its constituents</returns>
        public static Vector operator +(Vector first, Vector second)
        {
            return new Vector(first.X + second.X, first.Y + second.Y);
        }
    }
}
