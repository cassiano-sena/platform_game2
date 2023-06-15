using Godot;
using System;

public partial class Mapa_cassiano : Node2D
{
	public Area2D Coin;
	public AnimatedSprite2D animate;
	// // Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// // Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(double delta)
	// {
	// }
	
	//if(Coin=0){
	//	GetTree().ChangeSceneToFile("res://mapa_2.tcsn");
	//}
	
	
private void _on_checkpoint_2_body_entered(Node2D body)
{
	if(body is Jogador){
			((Jogador)body).newSavePoint();
			GD.Print("Checkpoint!");
			animate.Play("active");
		}
}	
}


//private void OnPropertyListChanged()
//{
//	
//}


//private void OnBodyEntered(Node2D body)
//{
//	// Replace with function body.
//}

