using System;
using UnityEngine;


public class statc
{

	public float speed = 0f;
	public float jumpingPower = 0f;

	

	public void SpeedAdd(float ADD)
		{
		this.speed += ADD;
		}

	public void JumpingADD(float ADD)
	{
		this.jumpingPower+= ADD;
	}
	public statc( float speed,float jumpingPower)
    {
		this.speed = speed;
		this.jumpingPower = jumpingPower;
		
    }

}