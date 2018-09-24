using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum TileType
    {
        ColorTile0,
        ColorTile1,
        ColorTile2,
        BlockTile,
        EmptyTile
    };

    public Color32 emptyTileColor;
    public Color32 blockTileColor;
    public Color32 Tile0Color;
    public Color32 Tile1Color;
    public Color32 Tile2Color;


    public Tile tilePrefab;
    private Tile[ , ] field;
    private int fieldSize = 5;
    private int tileColorTypes = 3;
    
    RaycastHit2D hit;

    void Start() {
        field = new Tile[fieldSize, fieldSize];

        for (int i = 0; i < fieldSize; i += 2)
        {
            for (int j = 1; j < fieldSize; j += 2)
            {
                field[i, j] = Instantiate(tilePrefab, new Vector3(j * 2, i * 2, 0), Quaternion.identity);
                field[i, j].type = TileType.BlockTile;
                field[i, j].GetComponent<SpriteRenderer>().color = blockTileColor;

            }
        }

        for (int i = 1; i < fieldSize; i += 2)
        {
            for (int j = 1; j < fieldSize; j += 2)
            {
                field[i, j] = Instantiate(tilePrefab, new Vector3(j * 2, i * 2, 0), Quaternion.identity);
                field[i, j].type = TileType.EmptyTile;
                field[i, j].GetComponent<SpriteRenderer>().color = emptyTileColor;

            }
        }

        int[] tileCount = new int[tileColorTypes];
        for (int i = 0; i < tileCount.Length; i++)
            tileCount[i] = fieldSize;


        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j += 2)
            {
                while (true)
                {
                    int type = Random.Range(0, tileColorTypes);

                    
                    if (tileCount[type] == 0)
                        continue;
                    tileCount[type]--;
                    switch (type)
                    {
                        case 0:
                            field[i, j] = Instantiate(tilePrefab, new Vector3(j * 2, i * 2, 0), Quaternion.identity);
                            field[i, j].type = TileType.ColorTile0;
                            field[i, j].GetComponent<SpriteRenderer>().color = Tile0Color;
                            break;

                        case 1:
                            field[i, j] = Instantiate(tilePrefab, new Vector3(j * 2, i * 2, 0), Quaternion.identity);
                            field[i, j].type = TileType.ColorTile1;
                            field[i, j].GetComponent<SpriteRenderer>().color = Tile1Color;
                            break;

                        case 2:
                            field[i, j] = Instantiate(tilePrefab, new Vector3(j * 2, i * 2, 0), Quaternion.identity);
                            field[i, j].type = TileType.ColorTile2;
                            field[i, j].GetComponent<SpriteRenderer>().color = Tile2Color;
                            break;

                        default:
                            continue;

                    }
                    break;
                }

            }
        }

       

    }


    void Update() {

         

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        }

        if (hit)
        {
            int j = (int)hit.transform.position.x / 2;
            int i = (int)hit.transform.position.y / 2;
            Debug.Log(" " + i + "  " + j);
            if (Input.GetAxis("Mouse X") < -0.5)
            {
                if (j > 0 && field[i, j - 1].type == TileType.EmptyTile)
                {
                    field[i, j - 1].GetComponent<SpriteRenderer>().color = field[i, j].GetComponent<SpriteRenderer>().color;
                    field[i, j - 1].type = field[i, j].type;
                    field[i, j].type = TileType.EmptyTile;
                    field[i, j].GetComponent<SpriteRenderer>().color = emptyTileColor;
                }

            }
            if (Input.GetAxis("Mouse X") > 0.5)
            {
                if (j < 4 && field[i, j + 1].type == TileType.EmptyTile)
                {
                    field[i, j + 1].GetComponent<SpriteRenderer>().color = field[i, j].GetComponent<SpriteRenderer>().color;
                    field[i, j + 1].type = field[i, j].type;
                    field[i, j].type = TileType.EmptyTile;
                    field[i, j].GetComponent<SpriteRenderer>().color = emptyTileColor;
                }
            }
            if (Input.GetAxis("Mouse Y") < -0.5)
            {
                if (i > 0 && field[i - 1, j].type == TileType.EmptyTile)
                {
                    field[i - 1, j].GetComponent<SpriteRenderer>().color = field[i, j].GetComponent<SpriteRenderer>().color;
                    field[i - 1, j].type = field[i, j].type;
                    field[i, j].type = TileType.EmptyTile;
                    field[i, j].GetComponent<SpriteRenderer>().color = emptyTileColor;
                }
            }
            if (Input.GetAxis("Mouse Y") > 0.5)
            {
                if (i < 4 && field[i + 1, j].type == TileType.EmptyTile)
                {
                    field[i + 1, j].GetComponent<SpriteRenderer>().color = field[i, j].GetComponent<SpriteRenderer>().color;
                    field[i + 1, j].type = field[i, j].type;
                    field[i, j].type = TileType.EmptyTile;
                    field[i, j].GetComponent<SpriteRenderer>().color = emptyTileColor;
                }
            }
        }
    }
    
}
