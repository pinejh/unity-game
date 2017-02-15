using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{

    public GameObject player;
    public SpriteRenderer sprite;
    public Text uiLives;
    public Text uiScore;

    public float moveSpeed;
    private float speedScale = 20;

    public int startingLives;
    private int lives;

    private bool left = false, right = false;

    public int invinceableTimer;
    private int invTimer;
    private bool isInv = false;

    public float timer;
    private float score;

	// Use this for initialization
	void Start ()
    {
        timer = 0;
        score = timer;
        lives = startingLives;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Increment timer
        timer++;

        //Sprite animator if currently invincible
        if(isInv)
        {
            invTimer--;
            if (invTimer%5==0 && sprite.enabled)
            {
                sprite.enabled = false;
            } else if (invTimer % 5 == 0 && !sprite.enabled)
            {
                sprite.enabled = true;
            }
            if (invTimer <= 0)
            {
                sprite.enabled = true;
                isInv = false;
            }
        }

        //Update lives on screen
        uiLives.text = "Lives: " + lives;

        //Update user input
        keyHandle();

        /*Processing user input*/
        //Side wall collisions for player

        //Movement towards the left
        if (left && !right)
        {   
            //Vector for player
            Vector3 newPlayer = new Vector3(player.transform.position.x - .77f, player.transform.position.y, player.transform.position.z);
            Vector3 tempPos = Camera.main.WorldToScreenPoint(newPlayer);

            //Check to see if moving left would stay onscreen
            if (tempPos.x + -1 * moveSpeed / speedScale >= 0)
            {
                player.transform.Translate(-1 * moveSpeed / speedScale, 0, 0);
            }
        }

        //Movement towards the right
        if (right && !left)
        {
            //Vector for player
            Vector3 newPlayer = new Vector3(player.transform.position.x + .77f, player.transform.position.y, player.transform.position.z);
            Vector3 tempPos = Camera.main.WorldToScreenPoint(newPlayer);

            //Check to see if moving left would stay onscreen
            if (tempPos.x + 1 * moveSpeed / speedScale <= Screen.width)
            {
                player.transform.Translate(1 * moveSpeed / speedScale, 0, 0);
            }
        }

        //Update score variable
        score = timer / 10;

        //Update score text on screen
        uiScore.text = "Score: " + Mathf.FloorToInt(score);
    }

    /*Method run upon collision of an asteriod*/
    public void takeDamage()
    {
        if (!isInv)
        {
            lives--;
            isInv = true;
            invTimer = invinceableTimer;
        }
    }

    /*Method that updates key variables to true*/
    void keyDown(KeyCode k)
    {
        switch (k)
        {
            case KeyCode.A:
                left = true;
                break;
            case KeyCode.D:
                right = true;
                break;
        }
    }

    /*Method that updates key variables to false*/
    void keyUp(KeyCode k)
    {
        switch (k)
        {
            case KeyCode.A:
                left = false;
                break;
            case KeyCode.D:
                right = false;
                break;
        }
    }

    /*Method that takes user input*/
    void keyHandle()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            keyDown(KeyCode.A);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            keyDown(KeyCode.D);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            keyUp(KeyCode.A);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            keyUp(KeyCode.D);
        }
        
    }

}
