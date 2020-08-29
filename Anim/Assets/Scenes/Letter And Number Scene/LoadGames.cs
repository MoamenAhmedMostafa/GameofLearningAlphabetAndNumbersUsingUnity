using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGames : MonoBehaviour {

	// Use this for initialization
   public void LoadLetterScene()
    {
        SceneManager.LoadScene("Letter");
    }
    
   public void LoadRandome()
    {
        SceneManager.LoadScene("Random");
    }
    public void LoadLevel1RunnerGame()
    {
        SceneManager.LoadScene("Level1 Game");
    }

   public void LoadMainMenue()
    {
        SceneManager.LoadScene("MaainMenue");
    }
}
