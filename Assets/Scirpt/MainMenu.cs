using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [SerializeField] private string nextlevl;

    public void playGame() {
        SceneManager.LoadScene(nextlevl);
    }

    public void QuitGame(){
        Debug.Log("KELUAR");
        Application.Quit();
    }
    
}
