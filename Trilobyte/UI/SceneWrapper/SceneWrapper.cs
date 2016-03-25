namespace Trilobyte
{
	public class SceneWrapper : ISceneWrapper
	{
		IScene CurrentScene;



		public void NavigateScene(IScene toNavigate)
		{
			CurrentScene = toNavigate;
		}

		public void Update(UpdateEventArgs e)
		{
			CurrentScene.Update(e);
			//UI.Update(e);
		}

		public string Write()
		{
			return CurrentScene.Write();
		}
	}
}
