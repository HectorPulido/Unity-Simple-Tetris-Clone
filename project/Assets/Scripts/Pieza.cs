using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza : MonoBehaviour {

	GameManager g;
	public bool activo = true;

	// Use this for initialization
	IEnumerator Start () 
	{
		g = GameManager.current;

		while (true) {
			
			transform.position += Vector3.down;

			if (TodoBien()) 
			{
				GridUpdate ();
			}
			else 
			{
				transform.position -= Vector3.down;
				activo = false;
				g.Revision ();
				g.s.instanciar ();
				break;
			}

			yield return new WaitForSeconds (.5f);
		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (activo) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				transform.position += Vector3.left;
				if (TodoBien ()) {
					GridUpdate ();
				} else {
					transform.position -= Vector3.left;
				}


			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				transform.position += Vector3.right;
				if (TodoBien ()) {
					GridUpdate ();
				} else {
					transform.position -= Vector3.right;
				}
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				transform.Rotate (0, 0, 90);
				if (TodoBien ()) {
					GridUpdate ();
				} else {
					transform.Rotate (0, 0, -90);
				}
			}
		}
	}

	bool TodoDentro()
	{
		for (int i = 0; i < transform.childCount; i++) {
			Transform t = transform.GetChild (i);
			if (!g.EstaDentro (t.position.x, t.position.y))
				return false;
		}

		return true;
	}

	bool TodoBien()
	{
		if (!TodoDentro())
			return false;

		for (int i = 0; i < transform.childCount; i++) {
			Transform t = transform.GetChild (i);
			Vector2Int v = new Vector2Int (t.position.x, t.position.y);
			if (g.Grid [v.x, v.y] != null) {
				if(g.Grid [v.x, v.y].parent != transform)
				{
					return false;
				}
			
			}
		}

		return true;

	}


	void GridUpdate()
	{
		for (int i = 0; i < g.TamañoDelTablero.x; i++) {
			for (int j = 0; j < g.TamañoDelTablero.y; j++) {
				if (g.Grid [i,j] != null) {
					if(g.Grid [i,j].parent == transform)
					{
						g.Grid [i, j] = null;
					}
				}
			}			
		}


		for (int i = 0; i < transform.childCount; i++) {
			Transform t = transform.GetChild (i);
			Vector2Int v = new Vector2Int (t.position.x, t.position.y);
			g.Grid [v.x, v.y] = t;
		}



	}

}
