using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.U2D;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private Transform map;


    [SerializeField]
    private Texture2D[] mapData;

    [SerializeField]
    private MapElement[] mapElements;

    [SerializeField]
    private Sprite defaultTile;

    [SerializeField]
    private SpriteAtlas waterAtlas;


    private Dictionary<Point, GameObject> waterTiles = new Dictionary<Point, GameObject>();


    private Vector3 WorldStartPos
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
        }
    }
    
    



	// Use this for initialization
	void Start () {

       
        GenerateMap();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void GenerateMap()
    {

        int height = mapData[0].height;
        int width = mapData[0].width;


     for(int i = 0; i < mapData.Length; i++)
        {
            for (int x = 0; x < mapData[i].width; x++)
            {
                for (int y = 0; y < mapData[i].height; y++)
                {
                    Color c = mapData[i].GetPixel(x, y);

                    MapElement newElement = Array.Find(mapElements, e => e.MyColour == c);

                    if (newElement != null)
                    {

                        float xpos = WorldStartPos.x + (defaultTile.bounds.size.x * x);
                        float ypos = WorldStartPos.y + (defaultTile.bounds.size.y * y);


                        GameObject go = Instantiate(newElement.MyElementPrefab);

                    
                        go.transform.position = new Vector2(xpos, ypos);
                        if (newElement.MyTileTag == "water")
                        {
                            waterTiles.Add(new Point(x,y), go);
                        }

                        if (newElement.MyTileTag == "Tree")
                        {
                            go.GetComponent<SpriteRenderer>().sortingOrder = height * 2 - y * 2 ;
                        }
                        go.transform.parent = map;


                    }

                }
            }
        }
        CheckWater();
    }


    public void CheckWater()
    {
        foreach (KeyValuePair<Point, GameObject> tile in waterTiles)
        {
            string composition = TileCheck(tile.Key);

            if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'E' && composition[6] == 'W')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("0");
            }
            if (composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'E' && composition[6] == 'W')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("1");
            }
            if (composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'E' && composition[6] == 'E')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("2");
            }
            if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'W')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("3");
            }
            if (composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'E')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("4");
            }
            if (composition[1] == 'E' && composition[3] == 'E' && composition[4] == 'W' && composition[6] == 'W')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("5");
            }
            if (composition[1] == 'W' && composition[4] == 'W' && composition[3] == 'E' && composition[6] == 'W')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("6");
            }
            if (composition[1] == 'W' && composition[3] == 'E' && composition[4] == 'W' && composition[6] == 'E')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("7");
            }
            if (composition[1] == 'W' && composition[3] == 'E' && composition[4] == 'E' && composition[6] == 'E')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("8");
            }
            if (composition[1] == 'E' && composition[3] == 'E' && composition[4] == 'E' && composition[6] == 'W')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("9");
            }
            if (composition[1] == 'W' && composition[3] == 'E' && composition[4] == 'E' && composition[6] == 'W')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("10");
            }
            if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'E')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("11");
            }
            if (composition[1] == 'E' && composition[3] == 'E' && composition[4] == 'W' && composition[6] == 'E')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("12");
            }
            if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'E' && composition[6] == 'E')
            {
                tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("13");
            }
            if (composition[3] == 'W' && composition[5] == 'E' && composition[6] == 'W')
            {
                GameObject go = Instantiate(tile.Value, tile.Value.transform.position, Quaternion.identity, map);
                go.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("14");
                go.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            if (composition[1] == 'W' && composition[2] == 'E' && composition[4] == 'W')
            {
                GameObject go = Instantiate(tile.Value, tile.Value.transform.position, Quaternion.identity, map);
                go.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("15");
                go.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            if (composition[4] == 'W' && composition[6] == 'W' && composition[7] == 'E')
            {
                GameObject go = Instantiate(tile.Value, tile.Value.transform.position, Quaternion.identity, map);
                go.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("16");
                go.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            if (composition[0] == 'E' && composition[1] == 'W' && composition[3] == 'W')
            {
                GameObject go = Instantiate(tile.Value, tile.Value.transform.position, Quaternion.identity, map);
                go.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("17");
                go.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            if (composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'W')
            {
                int randomTile = UnityEngine.Random.Range(0, 100);
                if (randomTile < 15)
                {
                    tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("19");
                }
            }
            if (composition[1] == 'W' && composition[2] == 'W' && composition[3] == 'W' && composition[4] == 'W' && composition[5] == 'W' && composition[6] == 'W')
            {
                int randomTile = UnityEngine.Random.Range(0, 100);
                if (randomTile < 10)
                {
                    tile.Value.GetComponent<SpriteRenderer>().sprite = waterAtlas.GetSprite("20");
                }

            }

        }
    }


    public String TileCheck(Point currentPoint)
    {
        string composition = string.Empty;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x !=0 || y != 0)
                {
                    if (waterTiles.ContainsKey(new Point(currentPoint.MyX + x, currentPoint.MyY + y)))
                    {
                        composition += "W";
                    }
                    else
                    {
                        composition += "E";
                    }
                }
            }
        }
        return composition;
    }



}

[Serializable]
public class MapElement
{
    [SerializeField]
    private String tileTag;

    [SerializeField]
    private Color Colour;

    [SerializeField]
    private GameObject elementPrefab;

    public GameObject MyElementPrefab
    {
        get
        {
            return elementPrefab;
        }

    }
   
    public Color MyColour
    {
        get
        {
            return Colour;
        }

        
    }

    public string MyTileTag
    {
        get
        {
            return tileTag;
        }

        
    }
}

public struct Point
{
    public int MyX { get; set; }
    public int MyY { get; set; }


    public Point(int x, int y)
    {
        this.MyX = x;
        this.MyY = y;
    }

}