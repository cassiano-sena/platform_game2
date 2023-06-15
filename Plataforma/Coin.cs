using Godot;
using System;

public partial class Coin : Area2D
{
	private AnimatedSprite2D animate;
	private CharacterBody2D Jogador;
	private Control Pontos;

	// // Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animate = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		animate.Play("default");
	}
	
	public void OnBodyEntered(Node2D body)
	{
	if(body is Jogador){
		//pontos.IncreaseScore();
		GD.Print("Dinheiro Coletado!");
		QueueFree();
	}
	}
}

