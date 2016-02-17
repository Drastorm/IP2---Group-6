using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {

	public float lastFall = 0;
	public bool placed = false;

	// Use this for initialization
	void Start () {
	
	}

	bool isValidGridPos(){
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2 (child.position);

			if (!Grid.insideBorder (v))
				return false;

			if (Grid.grids [(int)v.x, (int)v.y] != null && Grid.grids [(int)v.x, (int)v.y].parent != transform)
				return false;
		}

		return true;
	}

	void updateGrid(){

		for (int y = 0; y < Grid.h; ++y)
			for (int x = 0; x < Grid.w; ++x)
				if (Grid.grids [x, y] != null)
				if (Grid.grids [x, y].parent == transform)
					Grid.grids [x, y] = null;

		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2 (child.position);
			Grid.grids [(int)v.x, (int)v.y] = child;
		}
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {
			transform.position += new Vector3 (-1, 0, 0);

			if (isValidGridPos ())
				updateGrid ();
			else 
				transform.position += new Vector3 (1, 0, 0);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			transform.position += new Vector3 (1, 0, 0);

			if (isValidGridPos ())
				updateGrid ();
			else
				transform.position += new Vector3 (-1, 0, 0);
		} else if (Input.GetKeyDown (KeyCode.LeftShift)) {
			transform.Rotate (0, 0, -90);

			if (isValidGridPos ())
				updateGrid ();
			else
				transform.Rotate (0, 0, 90);
		} else if (Input.GetKeyDown (KeyCode.S) || Time.time - lastFall >=1) {
			transform.position += new Vector3 (0, -1, 0);

			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				transform.position += new Vector3 (0, 1, 0);

				//FindObjectOfType<spawner> ().spawnNext ();

				//placed = true;
				gameObject.tag = "Placed";
				enabled = false;
			}

			lastFall = Time.time;
		}

	}
}
