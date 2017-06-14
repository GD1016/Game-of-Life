using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessboard : MonoBehaviour {

    public int size = 10;
    public int field_x_variable = 10;
    public int field_y_variable = 10;

    GameObject[,] grid;


    // Use this for initialization
    void Start() {

        grid = new GameObject[field_x_variable, field_y_variable];

        for (int i = 0; i < field_x_variable; i++) {
            for (int j = 0; j < field_y_variable; j++) {
                GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Quad);
                tile.transform.position = new Vector2(i + 0.5f, j + 0.5f);
                tile.transform.parent = this.transform;
                //tile.name = ("Kachel (" + (i + 1) + "," + (j + 1) + ")");
                tile.name = string.Format("Kachel ({0},{1})", i + 1, j + 1);
                grid[i, j] = tile;

                int random = Random.Range(0, 10);
                if (random >= 5) {
                    tile.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }

        int camsize = field_x_variable / 2;
        Camera.main.transform.position = new Vector3(camsize, camsize, -10);
        Camera.main.orthographicSize = camsize;

        //grid[3, 3].GetComponent<Renderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update() {

    }
}
