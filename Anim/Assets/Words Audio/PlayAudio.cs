using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAudio : MonoBehaviour {
    public AudioClip[] audiclipLetter;
    public AudioClip[] audiclipNumber;
    private AudioSource audio;
    public Pause Ps;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void GotoMain()
    {
        SceneManager.LoadScene("SampleScene1");
    }
    public void GoToNumberScene()
    {
        SceneManager.LoadScene("Number");
    }
    public void z0()
    {
        StartCoroutine(playEngineSoundNumber(0));
    }
    public void z1()
    {
        StartCoroutine(playEngineSoundNumber(1));
    }
    public void z2()
    {
        StartCoroutine(playEngineSoundNumber(2));
    }
    public void z3()
    {
        StartCoroutine(playEngineSoundNumber(3));
    }
    public void z4()
    {
        StartCoroutine(playEngineSoundNumber(4));
    }
    public void z5()
    {
        StartCoroutine(playEngineSoundNumber(5));
    }
    public void z6()
    {
        StartCoroutine(playEngineSoundNumber(6));
    }
    public void z7()
    {
        StartCoroutine(playEngineSoundNumber(7));
    }
    public void z8()
    {
        StartCoroutine(playEngineSoundNumber(8));
    }
    public void z9()
    {
        StartCoroutine(playEngineSoundNumber(9));
    }
    public void a()
    {
        StartCoroutine(playEngineSoundLetter(0));
    }
    public void b()
    {
        StartCoroutine(playEngineSoundLetter(1));
    }
    public void c()
    {
        StartCoroutine(playEngineSoundLetter(2));

    }
    public void d()
    {
        StartCoroutine(playEngineSoundLetter(3));

    }
    public void e()
    {
        StartCoroutine(playEngineSoundLetter(4));

    }
    public void f()
    {
        StartCoroutine(playEngineSoundLetter(5));

    }
    public void g()
    {
        StartCoroutine(playEngineSoundLetter(6));

    }
    public void h()
    {
        StartCoroutine(playEngineSoundLetter(7));
    }
    public void i()
    {
        StartCoroutine(playEngineSoundLetter(8));
    }
    public void j()
    {
        StartCoroutine(playEngineSoundLetter(9));

    }
    public void k()
    {
        StartCoroutine(playEngineSoundLetter(10));

    }
    public void l()
    {
        StartCoroutine(playEngineSoundLetter(11));

    }
    public void m()
    {
        StartCoroutine(playEngineSoundLetter(12));

    }
    public void n()
    {
        StartCoroutine(playEngineSoundLetter(13));

    }
    public void o()
    {
        StartCoroutine(playEngineSoundLetter(14));

    }
    public void p()
    {
        StartCoroutine(playEngineSoundLetter(15));

    }
    public void q()
    {
        StartCoroutine(playEngineSoundLetter(16));

    }
    public void r()
    {
        StartCoroutine(playEngineSoundLetter(17));

    }
    public void s()
    {
        StartCoroutine(playEngineSoundLetter(18));

    }
    public void t()
    {
        StartCoroutine(playEngineSoundLetter(19));

    }
    public void u()
    {
        StartCoroutine(playEngineSoundLetter(20));

    }
    public void v()
    {
        StartCoroutine(playEngineSoundLetter(21));

    }
    public void w()
    {
        StartCoroutine(playEngineSoundLetter(22));

    }
    public void x()
    {
        StartCoroutine(playEngineSoundLetter(23));

    }
    public void y()
    {
        StartCoroutine(playEngineSoundLetter(24));

    }
    public void z()
    {
        StartCoroutine(playEngineSoundLetter(25));
    }
    IEnumerator playEngineSoundNumber(int cur)
    {
            audio.clip = audiclipNumber[cur];
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
    }
    IEnumerator playEngineSoundLetter(int cur)
    {
        audio.clip = audiclipLetter[cur];
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }
}
