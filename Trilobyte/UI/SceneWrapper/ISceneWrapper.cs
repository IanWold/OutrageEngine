namespace Trilobyte
{
	public interface ISceneWrapper : IViewable
	{
		void NavigateScene(IScene toNavigate);
	}
}