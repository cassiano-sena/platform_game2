using Godot;
using System;

public partial class Jogador : CharacterBody2D
{
	public bool isJumping = false;
	private int jumpCount;
	private Vector2 velocity;
	private Vector2 direction;
	private const int MaxJumps = 2;
	public Vector2 savePoint;
	public int Health = 6;
	public const float Speed = 200.0f;
	public const float JumpVelocity = -400.0f;
	public const float JumpVelocityLow = -300.0f;
	public const float JumpVelocityHigh = -350.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private AnimatedSprite2D animate;

	public override void _Ready() {
		animate = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	} //fim do ready

	public override void _PhysicsProcess(double delta)
	{
		//inercia inicial
		velocity = Velocity;
		
		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.	
		if(Input.IsActionJustPressed("Space")){
			Jump();
		}
		
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		// direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		direction = Input.GetVector("Left", "Right", "Up", "Down");
		if (direction != Vector2.Zero)
		{
			if(!IsOnFloor()){
				velocity.X = direction.X * (Speed/3)+20;
			}else velocity.X = direction.X * Speed;
		}
		else
		{
			//velocity.X = 0;
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed*(float)(4*delta));
		}

		Velocity = velocity;
		MoveAndSlide();

		Animation(velocity);
	} //fim do process

	private void Jump(){
		if(IsOnFloor()){
			jumpCount=0;
		}
		if(Input.IsActionPressed("Space") && jumpCount<=MaxJumps){
			velocity.Y=JumpVelocityHigh;
			jumpCount++;
		}
		if(Input.IsActionJustPressed("Space") && jumpCount<=MaxJumps){
			velocity.Y=JumpVelocityLow;
			jumpCount++;
		}
	}
	private void Animation(Vector2 velocity) {
		if (!IsOnFloor()){
			animate.Play("jump");
		}
		if(Input.IsActionJustPressed("Left")){
			animate.Play("run");
		}
		if(Input.IsActionJustPressed("Right")){
			animate.Play("run");
		}

		if (velocity.X != 0) {
			animate.Play("run");
		} else {
			animate.Play("idle");
		}

		// Scale=new Vector2(1,-1);

		//if(velocity.X=0){}
		if(velocity.X>0 && velocity.X!=0){
			animate.FlipH=true;
		}else if(velocity.X<0 && velocity.X!=0){
			animate.FlipH=false;
		}
	}

	public void newSavePoint(){
		// savePoint= new Vector2(7,5);
		savePoint=GlobalPosition;

	}

	public void ReturnToSavePoint(){
		GlobalPosition=savePoint;
	}

} //fim da classe
