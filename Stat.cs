using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stat : MonoBehaviour {
     private Image content;
     private float currentFill;
     public float MyMaxValue { get; set; }

    private float currentValue;

    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            currentValue = value;
        }
    }


    // Use this for initialization
    void Start () {
        content = GetComponent<Image>();
        content.fillAmount = 0.5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
