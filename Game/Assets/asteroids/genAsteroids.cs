using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genAsteroids : MonoBehaviour
{

    public GameObject self;
    public GameObject asteroid;
    public playerMove player;

	void Start ()
    {
		
	}
	

	void Update ()
    {
		if (player.timer % 120 == 0)
        {
            genAsteroid();
        }
	}

    void genAsteroid()
    {
        GameObject ast = Instantiate(asteroid, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        ast.transform.parent = self.transform;
    }

}
