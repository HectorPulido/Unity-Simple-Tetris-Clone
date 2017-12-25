using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Vector2Int
{
	public int x;
	public int y;


	public Vector2Int(int X, int Y)
	{
		x = X;
		y = Y;

	}
	public Vector2Int(float X, float Y)
	{
		x = Mathf.RoundToInt(X);
		y = Mathf.RoundToInt(Y);

	}

}


public class GameManager : MonoBehaviour 
{
	public static GameManager current;

	public Spawner s;
	public Vector2Int TamañoDelTablero;
	public Transform[,] Grid;



	void Awake () 
	{
		if (current != null)
			Destroy (gameObject);
		else
			current = this;

		Grid = new Transform[TamañoDelTablero.x, TamañoDelTablero.y];

	}

	public bool FilaLlena(int y)
	{
		for (int i = 0; i < TamañoDelTablero.x; i++) {
			if (Grid [i, y] == null)
				return false;
		}
		return true;
	}

	public bool EstaDentro(int x, int y)
	{
		if(x >= 0 && y >= 0 && y < TamañoDelTablero.y && x < TamañoDelTablero.x)
		{
			return true;
		}
		return false;

	}
	public bool EstaDentro(float x, float y)
	{
		return EstaDentro(Mathf.RoundToInt(x), Mathf.RoundToInt(y));

	}

	public void BorrarFila(int y)
	{
		for (int i = 0; i < TamañoDelTablero.x; i++) 
		{
			Destroy (Grid[i,y].gameObject);	
		}
		BajarFila (y + 1);
	}


	void BajarFila(int y)
	{
		if (y >= TamañoDelTablero.y)
			return;

		for (int i = 0; i < TamañoDelTablero.x; i++) 
		{
			if(Grid[i,y] != null)
			{
				Grid [i, y].position += Vector3.down;
				Grid [i, y - 1] = Grid [i, y];
				Grid [i, y] = null;
			}	
		}
		BajarFila (y + 1);

	
	}

	public void Revision()
	{
		for (int i = 0; i < TamañoDelTablero.y; i++) 
		{
			if (FilaLlena (i))
				BorrarFila (i);	
		}
	}





}
