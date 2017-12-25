using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	public GameObject[] prefabs;


	void Start()
	{
		instanciar ();	
	}

	public void instanciar()
	{
		Instantiate (prefabs[Random.Range(0, prefabs.Length)], transform.position, Quaternion.identity);

	}


}
