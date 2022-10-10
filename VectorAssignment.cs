using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorAssignment : ProcessingLite.GP21
{
	public Vector2 circlePosition;
	public float diameter = 2;
	int colorValue = 0;

    float MaxSpeed = 8;
    Vector2 myvec2;

    

	void Update()
	{
        //clean bakground
		Background(0);
		
		Circle(circlePosition.x, circlePosition.y, diameter);

    
		if (Input.GetMouseButtonDown(0))
		{  
            //this two lines is two diffrent options of a way to stop the vector/circle when the mouse is pressed down
            myvec2 *= 0;
            myvec2 = Vector2.zero;

            //if the color has the value 0. sett the circle on the sam position as the mouse is on in the moment.
			if (colorValue == 0)
			    {
				    colorValue = 255;
                    circlePosition.x = MouseX;
		            circlePosition.y = MouseY;
			    }
			else
			    {
				    colorValue = 0;
			    }
			
            //circle color
            Fill(128, colorValue, 128);
            }

        //if the mouse is pressed down, paint a line from the circle til the mouse.
        if (Input.GetMouseButton(0))
        {
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);
            //Debug.Log(myvec2); prints the calculation of the length of the vector
            
        }
        //
        if (Input.GetMouseButtonUp(0))
        {
            myvec2 = new Vector2(MouseX, MouseY) - circlePosition; //calculate the length of the vector
        }

        //takes the cicles position and change it so it moves in the direction of the vector  
        circlePosition = circlePosition + myvec2 * Time.deltaTime;

        //fråga robert igen om magnitude och normalized
        //elev sa: magnitude: om vektorn är extremt lång gör den den kortare om den är extremt kort gör den den längre så den är mer rimlig storlek
        
        if (myvec2.magnitude > MaxSpeed)
        {
            myvec2 = myvec2.normalized * MaxSpeed;
        }

        // om cirkelns position == som width av skärmen eller Height av skärmen
        // bytt riktning helt

        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log(Width);
            //Debug.Log(Height);
            //Debug.Log(circlePosition.x);
            //Debug.Log(circlePosition.y);
        }

        // bouncing
        if (circlePosition.x > Width)
        {
            myvec2.x *= -1;
        }
         if (circlePosition.y > Height)
        {
            myvec2.y *= -1;
        }
        if (circlePosition.x < 0.0)
        {
            myvec2.x *= -1;
        }
         if (circlePosition.y < 0.0)
        {
            //myvec2.y = -myvec2.y; Detta är ett annat sätt man kan byta riktiningen på
            myvec2.y *= -1;
        }
	}
}