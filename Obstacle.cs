using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Obstacle : MonoBehaviour, IComparable<Obstacle>{

    public SpriteRenderer MySpriteRenderer { get; set; }

    private Color defaultColour;
    private Color fadedColour;

    public int CompareTo(Obstacle other)
    {
       if (MySpriteRenderer.sortingOrder > other.MySpriteRenderer.sortingOrder)
        {
            return 1;
        }
       else if (MySpriteRenderer.sortingOrder < other.MySpriteRenderer.sortingOrder)
        {
            return -1;
        }
        return 0;
    }

    // Use this for initialization
    void Start () {

        MySpriteRenderer = GetComponent<SpriteRenderer>();
        defaultColour = MySpriteRenderer.color;
        fadedColour = defaultColour;
        fadedColour.a = 0.7f;

	}


    public void FadeOut()
    {
        MySpriteRenderer.color = fadedColour;
    }

    public void FadeIn()
    {
        MySpriteRenderer.color = defaultColour;
    }
	
	// Update is called once per frame
	void Update () {
		
	}




}
