using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	//The grid
	public static int w = 20;
	public static int h = 30;
	public static Transform[,] grids = new Transform[w,h];

	public static Vector2 roundVec2(Vector2 v){
		return new Vector2 (Mathf.Round (v.x), Mathf.Round (v.y));
	}

	public static bool insideBorder(Vector2 pos){
		return((int)pos.x >= 0 && (int)pos.x < w && (int)pos.y >= 0);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
