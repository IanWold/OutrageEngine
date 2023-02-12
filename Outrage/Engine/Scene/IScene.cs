namespace OutrageEngine.Engine.Scene
{
    using OutrageEngine.Engine.Camera;
    using OutrageEngine.Engine.Terrain;
    using OutrageEngine.Interfaces;

    /// <summary>
    ///  A 'scene' has a terrain (with entities) and a camera
    /// </summary>
    public interface IScene : IViewable
    {
        Camera FieldCamera { get; set; }

        ITerrainManager Terrain { get; set; }
    }
}
