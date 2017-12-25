using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public int[,] MiArray = new int[2,2];

	public bool EstaDentroDelArray(int x, int y)
	{
        //Lo primero que debes hacer aunque no es obligatorio es guardar en variables 
        //las dimensiones del array, de esta forma es mucho mas sencillo leer el codigo y no confundirte

        int MiArrayX = MiArray.GetLength(0);
        int MiArrayY = MiArray.GetLength(1);

        return (x >= 0 && y >= 0 && y < MiArrayY && x < MiArrayX); //Son 4 las comprobaciones que hay que hacer
        //Las dos primeras son comprobar que tanto X como Y sean mayores o iguales a cero 
        // Las otras dos es que sean MENORES que la dimension que estamos usando
	}

    public void Update()
    {
        //No se donde vas a poner tu codigo o que hace este pero va mas o menos asi
        if (EstaDentroDelArray(1, 1)) // Como 1,1 efectivamente esta dentro del array lo que va a dentro de este if, se ejecutara
        {
            //Foo
        }
    }
	
}
