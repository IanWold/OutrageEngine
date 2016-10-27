namespace Outrage
{
	/// <summary>
	/// Any entity is updatable and must handle collisions
	/// </summary>
	public interface IEntity : IUpdatable
	{
		bool CollideWith(CollisionEventArgs e);

		bool AppearEntity(CollisionEventArgs e);
	}
}
