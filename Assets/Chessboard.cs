using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessboard : MonoBehaviour {

    public int field_x_variable = 20;
    public int field_y_variable = 20;

    GameObject[,] grid;

    // Use this for initialization
    void Start() {

        grid = new GameObject[field_x_variable, field_y_variable];

        for (int i = 0; i < field_x_variable; i++) {
            for (int j = 0; j < field_y_variable; j++) {
                GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Quad);
                tile.transform.position = new Vector2(i + 0.5f, j + 0.5f);
                tile.transform.parent = this.transform;
                tile.name = string.Format("Kachel ({0},{1})", i, j);
                grid[i, j] = tile;

                int random = Random.Range(0, 10);
                if (random >= 5) {
                    tile.GetComponent<Renderer>().material.color = Color.blue;
                }
                //else {
                //    tile.GetComponent<Renderer>().material.color = Color.white;
                //}
            }
        }

        int camsize = field_x_variable / 2;
        Camera.main.transform.position = new Vector3(camsize, camsize, -10);
        Camera.main.orthographicSize = camsize;

        //Debug.Log("Alive Neighbours: " + GetAliveNeighbours(5, 5));
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) == false) {
            //return;
        }

        int[,] aliveCells = new int[field_x_variable, field_y_variable];
        for (int col = 0; col < field_y_variable; col++) {
            for (int row = 0; row < field_x_variable; row++) {
                aliveCells[col, row] = GetAliveNeighbours(col,row);
            }
        }



        for (int col = 0; col < field_y_variable; col++) {
            for (int row = 0; row < field_x_variable; row++) {
                int aliveNeighbours = aliveCells[col, row];

                if (grid[col, row].GetComponent<Renderer>().material.color == Color.white) {
                    if (aliveNeighbours == 3) {
                        grid[col, row].GetComponent<Renderer>().material.color = Color.blue;
                        print("Eine Zelle lebt wieder.");
                    }
                } else {
                    if (aliveNeighbours < 2 || aliveNeighbours > 3) {
                        grid[col, row].GetComponent<Renderer>().material.color = Color.white;
                        print("Eine Zelle stirbt.");
                    }
                }
            }
        }
    }

    private int GetAliveNeighbours(int col, int row) {
        int aliveNeighbours = 0;
        if (col - 1 >= 0 && grid[col - 1, row].GetComponent<Renderer>().material.color == Color.blue) {
            aliveNeighbours++;
        }
        if (col + 1 < field_x_variable && grid[col + 1, row].GetComponent<Renderer>().material.color == Color.blue) {
            aliveNeighbours++;
        }
        if (row + 1 < field_y_variable && grid[col, row + 1].GetComponent<Renderer>().material.color == Color.blue) {
            aliveNeighbours++;
        }
        if (row - 1 >= 0 && grid[col, row - 1].GetComponent<Renderer>().material.color == Color.blue) {
            aliveNeighbours++;
        }
        if (col - 1 >= 0 && row + 1 < field_y_variable && grid[col - 1, row + 1].GetComponent<Renderer>().material.color == Color.blue) {
            aliveNeighbours++;
        }
        if (col + 1 < field_x_variable && row + 1 < field_y_variable && grid[col + 1, row + 1].GetComponent<Renderer>().material.color == Color.blue) {
            aliveNeighbours++;
        }
        if (col - 1 >= 0 && row - 1 >= 0 && grid[col - 1, row - 1].GetComponent<Renderer>().material.color == Color.blue) {
            aliveNeighbours++;
        }
        if (col + 1 < field_x_variable && row - 1 >= 0 && grid[col + 1, row - 1].GetComponent<Renderer>().material.color == Color.blue) {
            aliveNeighbours++;
        }
        return aliveNeighbours;
    }
}