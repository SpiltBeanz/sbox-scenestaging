using Sandbox;

public sealed class MoveHelperDebugVis : Component
{
	[Property] Vector3 Gravity { get; set; }
	[Property] Vector3 Velocity { get; set; }

	protected override void OnUpdate()
	{
		
	}

	protected override void DrawGizmos()
	{
		var ts = (1.0f / 15.0f);

		BBox box = new BBox( new Vector3( -8, -8, 0 ), new Vector3( 8, 8, 48 ) );
		var pos = WorldPosition;
		var velocity = WorldRotation * Velocity;
		var trace = Scene.Trace.Size( box );

		for ( int i=0; i<100; i++ )
		{
			CharacterControllerHelper move = new CharacterControllerHelper( trace, pos, velocity );
			move.TryMoveWithStep( ts, 20.0f );
		//	move.TryMove( ts );

			pos = move.Position;
			velocity = move.Velocity;

			velocity = velocity + Gravity;
			velocity = velocity + WorldRotation * Velocity * 0.1f;

			using ( Gizmo.Scope( $"box {i}" ) )
			{
				Gizmo.Transform = new Transform( pos );
				Gizmo.Draw.Color = Color.White.WithAlpha( 0.8f );
				Gizmo.Draw.LineBBox( box );
			}
		}

		
	}
}
