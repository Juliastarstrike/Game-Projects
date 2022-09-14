//Julia Isaksson, få kvadrat att snurra och skjuta

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweekExample : MonoBehaviour
{
    public GameObject laserPrefab;
    public float x = 2;
    public float y = 3;
    public float size = 1;
    public float angle;

    public float fireRate = 0.2f;
    float timer;
    // Update is called once per frame
    void Update()
    {
        //fire laser
        if (Input.GetMouseButton(0) && timer > fireRate)
        {
            Instantiate(laserPrefab, transform.position, transform.rotation);
            timer = 0;

        }
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(laserPrefab, transform.position, transform.rotation);
        }
        x += Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5;
        y += Input.GetAxisRaw("Vertical") * Time.deltaTime * 5;

        transform.position = new Vector3(x,y);

       //Scale
        if (Input.GetKeyDown(KeyCode.E))
        {
            size++;

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            size--;
        }
        transform.localScale = Vector2.one * size;

        //Rotation
        Vector2 aim = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.up = aim;


        //transform.position = new Vector3(x, y);
        //transform.localScale = Vector2.one * size;
        //transform.eulerAngles = new Vector3(0, 0, angel);
    }
}

//   y++  ==   y + 1