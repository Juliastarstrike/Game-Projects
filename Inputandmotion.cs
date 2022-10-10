using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputandmotion : ProcessingLite.GP21
{
float diameter = 2;
// x och y position of the two ball/circle
float posY;
float posY2; 
float posX;
float posX2; 
float MaxSpeed = 7;
float speed = 2f; // constant velocity
Vector2 acc = Vector2.zero; // create a vector that controlls acceleration
Vector2 vel = Vector2.zero; // create a vector that controlls velocity

void Start()
{
  posX = Width / 2; //middle of the screen
  posY = Height / 2; //middle of the screen

  posX2 = Width / 2; //middle of the screen
  posY2 = Height / 2; //middle of the screen
}

void Update()
{
  //clean screen
  Background(50, 166, 240);
  
  //get the X.Y position from the bottons and adding velocity.
  posX += speed * Time.deltaTime* Input.GetAxisRaw("Horizontal") ;
  posY += speed * Time.deltaTime* Input.GetAxisRaw("Vertical") ;

  //aceleration on x 
  acc.x += Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5;

  //adds the aceleration and the speed to the position on x
  posX2 += speed * Time.deltaTime * acc.x;

  //aceleration on y
  acc.y += Input.GetAxisRaw("Vertical") * Time.deltaTime * 5;
  //adds the aceleration and the speed to the position on y
  posY2 += speed * Time.deltaTime * acc.y;

  //creatning circles
  //Circle(posX , posY, diameter);
  Circle(posX2 , posY2, diameter);

  //deacceleration
  if (Input.GetAxisRaw("Horizontal") == 0)
  {
    acc.x *= 1 - Time.deltaTime * 3;
  }
  if (Input.GetAxisRaw("Vertical") == 0)
  {
    acc.y *= 1 - Time.deltaTime * 15;
  }

  //Maxspeed set acceleration to zero
  if (acc.x < MaxSpeed * -1)
      acc = Vector2.zero;

  if (acc.y < MaxSpeed * -1)
      acc = Vector2.zero;

  if (acc.x > MaxSpeed )
      acc = Vector2.zero;

  if (acc.y > MaxSpeed )
      acc = Vector2.zero;
}
}