using Godot;
using System;
using Learining2;

public partial class Main_char : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public Logger _Logger;
	public string PressedButton;
	private int i = 0;

	public override void _Ready()
	{
		base._Ready();
		_Logger = new Logger();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		PressedButton = "none";

		
		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			PressedButton = "Jump";
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			if (Input.IsActionPressed("ui_left"))
			{
				PressedButton = "MoveLeft";
			}
			else if (Input.IsActionPressed("ui_right"))
			{
				PressedButton = "MoveRight";
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		
		i++;
		if (i % 5 == 0)
		{
			_Logger.Log(this);
			i = 0;
		}

		if (Input.IsActionPressed("ui_cancel"))
		{
			GetTree().Quit();
		}
	}
	
	
}
