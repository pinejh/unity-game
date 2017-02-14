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
        timer++;
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
        uiLives.text = "Lives: " + lives;
        keyHandle();
        if (left && !right)
        {
            player.transform.Translate(-1 * moveSpeed / speedScale, 0, 0);
        }
        if (right && !left)
        {
            player.transform.Translate(1 * moveSpeed / speedScale, 0, 0);
        }
        score = timer / 10;
        uiScore.text = "Score: " + Mathf.FloorToInt(score);
    }

    public void takeDamage()
    {
        if (!isInv)
        {
            lives--;
            isInv = true;
            invTimer = invinceableTimer;
        }
    }

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
