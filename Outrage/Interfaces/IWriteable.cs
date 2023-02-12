namespace OutrageEngine.Interfaces
{
    /// <summary>
    /// Anything which the game loop (or something else, maybe) can call to get a string representation of its display
    /// </summary>
    public interface IWriteable
    {
        string Write();
    }
}
