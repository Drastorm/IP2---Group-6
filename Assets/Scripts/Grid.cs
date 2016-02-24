using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	//The grid
	public static int w = 21;
	public static int h = 35;
	public static Transform[,] grids = new Transform[w,h];

	public static Vector2 roundVec2(Vector2 v){
		return new Vector2 (Mathf.Round (v.x), Mathf.Round (v.y));
	}

	public static bool insideBorder(Vector2 pos){
		return((int)pos.x >= 0 && (int)pos.x < w && (int)pos.y >= 0);
	}

	public static void deleteRow(int y)
	{
		for (int x = 0; x < w; x++) 
		{
			Destroy(grids[x,y].gameObject);
			grids[x,y] = null;
		}
	}
	
	public static void decreaseRow(int y)
	{
		for (int x = 0; x < w; x++) {
			if (grids [x, y] != null) {
				grids [x, y - 1] = grids [x, y];
				grids [x, y] = null;
				
				grids [x, y - 1].position += new Vector3 (0, -1, 0);
			}
		}
	}
	
	public static void decreaseRowsAbove(int y)
	{
		for (int i = y; i < h; i++)
			decreaseRow (i);
	}
	
	public static bool isRowFull(int y)
	{
		for (int x = 0; x < w; x++)
			if (grids [x, y] == null)
				return false;
		return true;
	}
	
	public static void deleteFullRows()
	{
		for (int y = 0; y < h; y++) 
		{
			if(isRowFull(y))
			{
				deleteRow(y);
				decreaseRowsAbove(y+1);
				y--;
			}
		}
	}
}
