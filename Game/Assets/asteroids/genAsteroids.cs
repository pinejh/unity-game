using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genAsteroids : MonoBehaviour
{
    //"Folder/Arraylist" for asteroids
    public GameObject self;


    public GameObject asteroid;
    public playerMove player;

	void Start ()
    {
		
	}
	

    //Timer that generates asteroids
	void Update ()
    {
		if (player.timer % 120 == 0)
        {
            genAsteroid();
        }
	}

    //Method that instantiates the asteroid objects
    void genAsteroid()
    {
        GameObject ast = Instantiate(asteroid, new Vector3(transform.position.x + Random.Range(-6.5f, 6.5f), transform.position.y, transform.position.z), Quaternion.identity);
        ast.transform.parent = self.transform;
    }

}
