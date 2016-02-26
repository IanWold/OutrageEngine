using System;
using System.Collections.Generic;
using System.Linq;

namespace Trilobyte
{
	public class Level : ILevel
	{
		List<IScene> Scenes { get; set; }

		int CurrentScene { get; set; }

		public string Name { get; }

		public delegate void OnUpdateEventHandler(object sender, UpdateEventArgs e);
		public event OnUpdateEventHandler OnUpdate;

		public Level(string name, IScene scene)
		{
			Name = name;

			Scenes = new List<IScene>();
			Add(scene);

			CurrentScene = 0;
		}

		public void Add(IScene toAdd)
		{
			toAdd.ParentLevel = this;
			Scenes.Add(toAdd);
		}

		public void ChangeScene(string toChange)
		{
			CurrentScene = GetIndex(toChange);
		}

		int GetIndex(string toGet)
		{
			for (int i = 0; i < Scenes.Count; i++)
			{
				if (Scenes[i].Name == toGet) return i;
			}

			throw new ArgumentException("That scene doesn't exist.");
		}

		public IScene Get(string toGet)
		{
			foreach (var s in Scenes)
			{
				if (s.Name == toGet) return s;
			}

			throw new ArgumentException("That scene doesn't exist.");
		}

		public void Update(UpdateEventArgs e)
		{
			Scenes[CurrentScene].Update(e);
			if (OnUpdate != null) OnUpdate(this, e);
		}

		public string Write()
		{
			return Scenes[CurrentScene].Write();
		}
	}
}
