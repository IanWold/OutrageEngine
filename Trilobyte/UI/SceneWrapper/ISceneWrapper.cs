namespace Outrage
{
	public interface ISceneWrapper : IViewable
	{
		void NavigateScene(IScene toNavigate);
	}
}