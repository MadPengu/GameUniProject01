using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public Camera Playercam;
    public Camera Mapcam;
    public Camera Rendercam;
    public GameObject Renderer;


	// Use this for initialization
	void Start () {
        Playercam.enabled = true;
        Mapcam.enabled = false;
        Rendercam.enabled = true;
        Renderer.SetActive(true) ;
        
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("m"))
        {
            Mini();

        }
        if (Input.GetKeyUp("m"))
        {
            Full();
        }
		
	}


    void Mini()
    {
          Playercam.enabled = false;
          Mapcam.enabled = true;
          Rendercam.enabled = false;
          Renderer.SetActive(false);

    }

    void Full()
    {
        Playercam.enabled = true;
        Mapcam.enabled = false;
        Rendercam.enabled = true;
        Renderer.SetActive(true);
    }
}
