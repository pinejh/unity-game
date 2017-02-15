using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{

    public GameObject ast;
    public PolygonCollider2D polyCol;

    public float speed;
    private float speedScale = 50;

    private playerMove player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>();
	}
	
	
	void Update ()
    {
        ast.transform.Translate(0, -speed/speedScale, 0);
        if (ast.transform.position.y <= -6)
        {
            destroy();
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        player.takeDamage();
        destroy();
    }

    void destroy()
    {
        Destroy(ast);
    }

}
