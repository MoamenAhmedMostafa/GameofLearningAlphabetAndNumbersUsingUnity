using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadLevel1 : MonoBehaviour {
    public Pause Ps;
	void Start () {
	}
	
	void Update () {
		
	}
	public void OPenScene()
   {
	   SceneManager.LoadScene("SampleScene1");
   }
    public void RestartLevel1()
    {
        Pause.paused = false;
        Time.timeScale = 1;

        SceneManager.LoadScene("Level1 Game");
    }
    public void RestartLevel2()
    {
        Pause.paused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Level2 Game");
    }
    public void GoToMain()
    {
        SceneManager.LoadScene("SampleScene1");
    }
    public void Eixt_Game(){
         UnityEditor.EditorApplication.isPlaying = false;
	}
	public void LoadSetting()
	{
			   SceneManager.LoadScene("Setting");
	}
}
