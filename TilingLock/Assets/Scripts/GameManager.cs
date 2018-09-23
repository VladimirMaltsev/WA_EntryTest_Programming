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

    public Tile tilePrefab;
    private Tile[ , ] field;
    private int fieldSize = 5;
    private int tileColorTypes = 3;

    void Start() {
        //field = new Tile[fieldSize, fieldSize];
        field = new Tile[fieldSize, fieldSize];

        for (int i = 0; i < fieldSize; i += 2)
        {
            for (int j = 1; j < fieldSize; j += 2)
            {
                //field[i, j] = new Tile(TileType.BlockTile);
                field[i, j] = Instantiate(tilePrefab, new Vector3(j * 2, i * 2, 0), Quaternion.identity);
                field[i, j].type = TileType.BlockTile;
                field[i, j].GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 222);

            }
        }

        for (int i = 1; i < fieldSize; i += 2)
        {
            for (int j = 1; j < fieldSize; j += 2)
            {
                field[i, j] = Instantiate(tilePrefab, new Vector3(j * 2, i * 2, 0), Quaternion.identity);
                field[i, j].type = TileType.EmptyTile;
                field[i, j].GetComponent<SpriteRenderer>().color = new Color32(20, 20, 20, 222);

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
                            field[i, j].GetComponent<SpriteRenderer>().color = new Color32(200, 0, 0, 222);
                            break;

                        case 1:
                            field[i, j] = Instantiate(tilePrefab, new Vector3(j * 2, i * 2, 0), Quaternion.identity);
                            field[i, j].type = TileType.ColorTile1;
                            field[i, j].GetComponent<SpriteRenderer>().color = new Color32(0, 200, 0, 222);
                            break;

                        case 2:
                            field[i, j] = Instantiate(tilePrefab, new Vector3(j * 2, i * 2, 0), Quaternion.identity);
                            field[i, j].type = TileType.ColorTile2;
                            field[i, j].GetComponent<SpriteRenderer>().color = new Color32(0, 0, 200, 222);
                            break;

                        default:
                            continue;

                    }
                    break;
                }

            }
        }

       

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
