using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loop : ProcessingLite.GP21
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   float spaceBetweenLines = 0.5f;


void Update()
{
  //Clear background
  Background(50, 200, 240);

//Line(0, 10, 1, 0);
//Line(0, 9, 2, 0);
//Line(0, 8, 3, 0);
//Line(0, 7, 4, 0);

for (int i = 0; i < Height / spaceBetweenLines; i++)
{
  if (i % 3 == 0)
  {
    int r =Random.Range(0, 256);
    int g =Random.Range(0, 256);
    int b =Random.Range(0, 256);
    Stroke(r, g, b);
  }
  else
  {
    Stroke(255);
  }

  Line(0, Height - i * spaceBetweenLines, Width * i / (Height / spaceBetweenLines), 0);
}
//{
  //Line(0, Height - i *spaceBetweenLines, i, 0);
//}

  //Draw our scan lines
  //for (int i = 0; i < Height / spaceBetweenLines; i++)
  //{
    //Increase y-cord each time loop run
    //float y = i * spaceBetweenLines;

    //Draw a line from left side of screen to the right
    //Line(-1, y-1, Width, y);
  }
}

