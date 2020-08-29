using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Rand : MonoBehaviour {

    public AudioClip[] audiclip;
    private AudioSource audio;
    public Sprite[] imgs;
    public Text Show,WinandLose;
    public Text Show_score;
    public Text Show_Health;
    public Text Show_PlayAgain;
    public Image result;
    public Sprite[] valresult;
    public GameObject btn1,btn2,btn3,btn4;
    void Start ()
    {
        audio = GetComponent<AudioSource>();
        random_array();
		dispaly_on_btn();
        //audio.clip = audiclip[five_letter[cur]];
        //audio.Play();
        //Show.sprite = Letters[five_letter[cur]];
        //Show.sprite = Letters[0];
        //Show.IsActive();
        //Show.gameObject{ Letters[0]; };
        // Show.sprite = (Sprite)Letters[0];
        Health = 3;
    }
	string name_button="";
	int score=0;
	int cur=0;
	bool lose=false;
	float Timer=0;
    int Health;
    void Update ()
    {
        Show_score.text="Score : "+score.ToString();
		if(lose)
        {
            Show.gameObject.SetActive(false);
            WinandLose.gameObject.SetActive(true);
            WinandLose.text = "You Lose ...";
            Show_PlayAgain.text = "Press Space To Play Again :-)...";
            Timer += Time.deltaTime;
            if (Timer >= 0.5)
                Show_PlayAgain.gameObject.SetActive(false);
            if( Timer >=1)
            {
                Show_PlayAgain.gameObject.SetActive(true);
                Timer = 0;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("Random");
            }
		}
		else {
			if(score==10){
                Show.gameObject.SetActive(false);
                WinandLose.gameObject.SetActive(true);
              WinandLose.text="Congratulations, You Win!";
             Show_PlayAgain.text = "Press Space To Play Again :-)...";
                Timer +=Time.deltaTime;
            if (Timer >= 0.5)
                    Show_PlayAgain.gameObject.SetActive(false);
            if( Timer >=1)
            {
                    Show_PlayAgain.gameObject.SetActive(true);
                Timer = 0;
            }
                if (Input.GetKey(KeyCode.Space))
                {
                    SceneManager.LoadScene("Random");
                }

            }
			 else {
		if(name_button.Equals(""));
		else {
              if(imgs[(int)(name_button[3]-'0')-1].name.Equals(Show.text)){
				  cur++;
				  score++;
                 StartCoroutine(playTrueOrFalse(1));
                  random_array();
				  dispaly_on_btn();
			  }
			  else
              {
                 Health--;
                 Show_Health.text = "Health:#" + Health.ToString();
                 StartCoroutine(playTrueOrFalse(0));
                  if (Health<=0)
				  lose=true;
			  }
			  name_button="";
		}
		
		}
		}
	}
    IEnumerator playTrueOrFalse(int cur)
    {
        result.gameObject.SetActive(true);
        result.sprite = valresult[cur];
        yield return new WaitForSeconds(1);
        result.gameObject.SetActive(false);


    }
    public void click(){
		name_button=EventSystem.current.currentSelectedGameObject.name;
		Debug.Log(name_button);
	}
	void random_array(){
		int rand=0;
		 while(rand<20){
            int l=Random.Range(0,10)%10;
            int r=Random.Range(0,10)%10;
            Sprite s=imgs[l];
            imgs[l]=imgs[r];
            imgs[r]=s;
            AudioClip t = audiclip[r];
            audiclip[r] = audiclip[l];
            audiclip[l] = t;
            rand++;
            } 
	}
    IEnumerator Play(int cur)
    {
        audio.clip = audiclip[cur];
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }
    void dispaly_on_btn(){
		btn1.GetComponent<Image>().sprite=imgs[0];
		btn2.GetComponent<Image>().sprite=imgs[1];
		btn3.GetComponent<Image>().sprite=imgs[2];
		btn4.GetComponent<Image>().sprite=imgs[3];
		int r=Random.Range(0,4)%4;
		Show.text=imgs[r].name;
        StartCoroutine(Play(r));
    }
    public void LoadMainMennue()
    {
        SceneManager.LoadScene("SampleScene1");
    }
}
