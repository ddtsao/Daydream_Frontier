using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NormalATKController : MonoBehaviour
{
    public Animator animator1;
    public Animator animator2;
    public AudioSource AS1;
    public AudioSource AS2;
    public AudioSource AS3;
    public AudioSource AS4;
    public Button button;
    public Button button2; 
    public int[] index;
    public int[] x;
    public int[] y;

    // Start is called before the first frame update
    void Start()
    {
        animator1 = GetComponent<Animator>();
        InvokeRepeating("SetButton", 1.0f, 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("enemy_wolf").GetComponent<Enemy>().Hp_Enemy <= 0)
        {
            animator1.SetInteger("random_atk", 100);
        }
        else
        {
            animator1.SetInteger("random_atk", index[Random.Range(0, index.Length)]);
        }
    }
    public void CancelPlay()
    {
        animator1.speed = 0;
    }
    public void StartPlay()
    {
        animator1.speed = 1;
    }
    public void Check()
    {
        if(!animator1.GetCurrentAnimatorStateInfo(0).IsName("wolf_atk_idle"))
        {
            return;
        }
        else
        {
            GameObject.Find("SkillField").GetComponent<BattleSkill>().GetSpDamage(75);
            animator2.SetTrigger("show_atk");
            animator1.speed = 0;
        }
    }
    public void skip()
    {
        animator1.Play("introduce 1", 0, 0.93f);
    }
    public void NormalCheck(string a, string b)
    {
        if(!animator1.GetCurrentAnimatorStateInfo(0).IsName(a))
        {
            return;
        }
        else
        {
            animator2.SetTrigger(b);
            animator1.speed = 0;
        }
    }
    void SetButton()
    {
        if(animator1.GetCurrentAnimatorStateInfo(0).IsName("wolf_atk_idle"))
        {
            int i = Random.Range(0, 3);
            button.transform.localPosition = new Vector3(Random.Range(-114.0f, 130.0f), Random.Range(34.0f, 193.0f), 10.0f);
            button2.transform.localPosition = new Vector3(x[i], y[i], 10.0f);
        }
    }
    void SwingAudio()
    {
        AS1.Play(); 
    }
    void RoarAudio()
    {
        AS2.Play(); 
    }
    void DamageAudio()
    {
        AS3.Play(); 
    }
    void DieAudio()
    {
        AS4.Play(); 
    }
}