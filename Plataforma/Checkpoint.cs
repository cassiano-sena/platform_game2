using Godot;
using System;

public partial class Checkpoint : Area2D
{
	private AnimatedSprite2D animate;
	private CharacterBody2D Jogador;
	private Vector2 savePoint;

	// // Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animate = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// // Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(double delta)
	// {
	// }
	
	private void OnBodyEntered(Node2D body)
	{
		if(body is Jogador){
				((Jogador)body).newSavePoint();
				GD.Print("Checkpoint!");
				animate.Play("active");
			}
	}
}



