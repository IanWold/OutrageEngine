﻿namespace Outrage
{
	/// <summary>
	/// Any thing which needs to do work in the game needs to update
	/// </summary>
	public interface IUpdatable
	{
		void Update(UpdateEventArgs e);
	}
}
