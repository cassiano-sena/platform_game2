using Godot;
using System;

public partial class Killzone : Area2D
{
	private AnimatedSprite2D animate;
	private CharacterBody2D Jogador;

	// // Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animate = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// // Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(double delta)
	// {
	// }
	public void OnBodyEntered(Node2D body)
	{
	if(body is Jogador){
		((Jogador)body).ReturnToSavePoint();
		GD.Print("Entrou na área de morte!");
	}
	}
}


