using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text restart_text;
    public Text gameover_text;
    public Text quit_text;

    private bool gameover;
    private bool restart;
    private bool quit;
    protected bool restartIndctr;
    // Use this for initialization
    void Start () {
        restart = false;
        gameover = false;
        quit = false;
        restart_text.text = "";
        gameover_text.text = "";
        quit_text.text = "";
        //StartCoroutine(TextMenu());
    }
	
	// Update is called once per frame
	void Update () {
        gameover = MovementPlayer.InfoGameover;
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);                
            }            
        }

        if (quit)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
        if (restartIndctr) {
            restart = false;
            gameover = false;
            quit = false;
            restart_text.text = "";
            gameover_text.text = "";
            quit_text.text = "";
        }
        game_over(gameover);
    }

    public void game_over(bool x)
    {       
        if (x)
        {
            gameover_text.text = "Game Over";            
            restart_text.text = " Press 'R' to restart";
            quit_text.text = " Press 'Q' to quit the game";
            restart = true;
            quit = true;
        }
    }

}
