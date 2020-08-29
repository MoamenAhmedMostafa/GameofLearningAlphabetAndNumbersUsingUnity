using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movemnet : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D rb2d;
    private Animator anim;
    public GameObject cam;
    //public Pause ps;
    GameObject first_stat;
    public GameObject brid;
    public GameObject tnt;
    public GameObject coin;
    public Text Health,gameOverTxt,PressSpace;
    public GameObject []let;
    public Sprite[] Letters;
    public AudioClip[] audiclip;
    public Image Show;
    private AudioSource audio;
    int[] five_letter;
    private float groundHorizontalSize=11.379f;
    public GameObject g1,g2;
    int cur = 0,turn=1;
    float cnt=0;
    float Timer=0;
    int Death=3;

    void Start ()
    {
        Time.timeScale = 1;
        groundHorizontalSize = Vector3.Distance(g1.transform.position,g2.transform.position);
        cur = 0;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
            anim.SetBool("Move", true);
        five_letter = new int[7];

        audio = GetComponent<AudioSource>();
        for(int i = 0; i < 7; i++)
        {
            int x = Random.Range(0, 26) % 26;
            five_letter[i] = x;
        }

        //audio.clip = audiclip[five_letter[cur]];
        //audio.Play();
        Show.sprite = Letters[five_letter[cur]];
        StartCoroutine(playEngineSound(cur, true));
    }

    //Update is called once per frame
    float call_create=0,x=0,oldx=0,tnt_cnt=0;
     bool ok=false;
   float createBird=0;
   GameObject brd,tnt_c;
    void Update ()
    {
       // first_stat.transform.rotation =transform.rotation;
     transform.rotation=Quaternion.Euler(0,0,0);
     createBird+=Time.deltaTime;
     if(createBird>=22){
         create_bird();
         createBird=0;
     }
        if(brd!=null){
            brd.transform.Translate(-x * Time.deltaTime*15, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //  rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, 200f));
            if(transform.position.y>=3.52f){
               transform.position=new Vector3 (transform.position.x,3.52f,0);
              rb2d.velocity = Vector2.zero;
             }
             
            anim.SetBool("Jump", true);
            // anim.SetTrigger("Flap");

        }

         x = .1f;
       // if (Input.GetKeyDown(KeyCode.D))
            //  rb2d.velocity = Vector2.zero;
           call_create+=transform.position.x-oldx;
           tnt_cnt+=transform.position.x-oldx;
           oldx=transform.position.x;
           if(tnt_cnt>=50){
             //  create_tnt();
             create_conins();
               tnt_cnt=0;
           }
           if(call_create>=6.5){
             create_letter();call_create=0;
              }
            
            if(Death>0)transform.Translate(x * Time.deltaTime*20, 0, 0);

            float po_char_x=transform.position.x;
            cam.transform.position=new Vector3 (po_char_x+7.8f,0.26f,-10);
            // anim.SetTrigger("Flap");
            //while (Input.GetKeyDown(KeyCode.D));
           
       if(transform.position.y>=3.52){
               transform.position=new Vector3 (transform.position.x,3.52f,0);
              //rb2d.velocity = Vector2.zero;
             }
        {
		if(turn==1){
                float dis=Vector3.Distance(g2.transform.position,cam.transform.position);

                 if(dis>=25)g2.transform.position = (Vector2)g1.transform.position +
		  (new Vector2(groundHorizontalSize, 0));
                     turn=2;
                   }
		if(turn==2) {
                 float dis=Vector3.Distance(g1.transform.position,cam.transform.position);
                 if(dis>=25)
                  g1.transform.position = (Vector2)g2.transform.position + 
			(new Vector2(groundHorizontalSize, 0));
			cnt=0;
                       turn=1;
                  }
	}

   if(Death<=0)
   {
     
        Timer+=Time.deltaTime;
            if (Timer >= 0.5)
                gameOverTxt.gameObject.SetActive(false);
            if( Timer >=1)
            {
                gameOverTxt.gameObject.SetActive(true);
                Timer = 0;
            }


   }
    }

   void FixedUpdate(){
    
   }
    void OnTriggerEnter2D(Collider2D col)
    {
        string cur_letter = "";

        cur_letter += (char)(five_letter[cur] + 'A');
              cur_letter+= "(Clone)";
        if(col.gameObject.name.Equals("TNT(Clone)")){
            tnt_c.GetComponent<Animator>().SetBool("Explosion",true);
            //tnt_c.GetComponent<Animator>().SetBool("Explosion",false);
        }
        if (col.gameObject.name.Equals(cur_letter))
        {
            cur++;
            if(cur==5){
	         SceneManager.LoadScene("Level2 Game");
            }
            StartCoroutine(playEngineSound(cur, true));
            Show.sprite = Letters[five_letter[cur]];
            // Debug.Log("AAA");
            // audio.clip = audiclip[five_letter[cur]];
            // audio.Play();
        }
        else
        {
        if(col.gameObject.name.Equals("Coin(Clone)"))Death++;
        else Death--;
        if(Death>3)Death=3;
          if(Death>0)
          {
               Health.text="Health:#"+Death.ToString();
        // yield WaitForSeconds (0.25);   
              }
          else
          {
            //  Death=3;
              Health.text="Health:#0";
             PressSpace.gameObject.SetActive(true);

          }
          
        }
    }

    void OnCollisionEnter2D(Collision2D col)  
    {
        //
        if (col.gameObject.name.Equals("Ground1")||col.gameObject.name.Equals("Ground2")|| col.gameObject.name.Equals("mtb1") || col.gameObject.name.Equals("mtb2") || col.gameObject.name.Equals("mtb3"))
        {
            anim.SetBool("Jump", false);

        } 
        if(col.gameObject.name.Equals("Ground1")){
		turn=1;
        }
       else {
		turn=2;
        }
    }
   void create_letter()
    {

   float minimum=(float)(cam.transform.position.x+19.5f)*1.0f;
   float maximum=(float)(cam.transform.position.x+19.5f + 6.50f)*1.0f;
   float r=(float)Random.Range(1, 100);
    r/=100.0f;
   float x=r * (maximum - minimum) + minimum;
   minimum=-2.812f;
   maximum=4.3f;
   float y=r * (maximum - minimum) + minimum;
       var theNewPos= new Vector3 (x,y,0.0f);

       Instantiate(let[five_letter[Random.Range(0,7)%7]],theNewPos,cam.transform.rotation);
   }
   void create_bird(){
     brd=(GameObject)Instantiate(brid,cam.transform.position+new Vector3(20f,2.6f,10f),cam.transform.rotation);
   }
    void create_tnt()
    {
        tnt_c=(GameObject) Instantiate(tnt,cam.transform.position+new Vector3(Random.Range(0,10)*1.2f,-3.33f,10f),cam.transform.rotation);
    }
    void create_conins()
    {
        Instantiate(coin,cam.transform.position+new Vector3(Random.Range(10,20)*1.5f,-3.33f,10f),cam.transform.rotation);
    }

    IEnumerator playEngineSound(int cur, bool collect)
    {
        if (collect)
        {
            audio.clip = audiclip[26];
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
        }
        audio.clip = audiclip[five_letter[cur]];
        audio.Play();
    }
}
