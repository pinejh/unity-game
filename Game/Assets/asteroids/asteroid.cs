using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Object class for asteroids
 */
public class asteroid : MonoBehaviour
{
    //Variable for single asteroid object
    public GameObject ast;

    //Collider for asteroid object
    public PolygonCollider2D polyCol;

    //Rate at which asteroid falls
    public float speed;

    //Multiplier so that the speed variable can be more legible in smaller contexts
    private float speedScale = 50;


    private playerMove player;

    /*
     * Method that retrieves and assigns player variable
     * Used later in player takeDamage() method
     */
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>();
	}

    /*
     * @Update every frame
     * Method that moves the asteroid
     */
    void Update ()
    {
        //Move the asteroid
        ast.transform.Translate(0, -speed/speedScale, 0);

        //If the asteroid is below the screen
        if (ast.transform.position.y <= -6)
        {
            destroy();
        }
	}

    /*
     * Upon collision with a player / "object"
     */
    void OnTriggerEnter2D(Collider2D other)
    {
        //Make player take damage
        player.takeDamage();

        //Destroy the asteroid object
        destroy();
    }

    /*
     * Method that destroys the asteroid object
     */
    void destroy()
    {
        Destroy(ast);
    }

}
