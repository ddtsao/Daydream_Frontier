using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SmokeBlast : MonoBehaviour
{
    public Image smokeBlast;
    public Image blade;
    public Animator anim;
    public Animator anim2;
    public Animation animation;
    public Animator animation2;
    public RectTransform Blood;
    public List<GameObject> btns;
    public List<AudioSource> audioSources;
    public int CountPB = 0;
    public int CountUlt = 0;
    public int CountBB = 0;
    public int wallCount = 0;
    private bool a1 = true;

    private void Start()
    {
        InvokeRepeating("PlaySmokeBlast", 1.0f, 0.5f);
        InvokeRepeating("PlayBlade", 1.0f, 0.5f);
        InvokeRepeating("EnemyUlt", 1.0f, 0.5f);
        InvokeRepeating("BloodWall", 1.0f, 1.0f);
        InvokeRepeating("SpAddition", 1.0f, 2.0f);
    }
    private void FixedUpdate()
    {
        BloodBlade();
    }
    void NoBlock()
    {
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("FogBlast_idle"))
        {
            GameObject.Find("Backpack").GetComponent<GraphicRaycaster>().enabled = false;
            GameObject.Find("Menu").GetComponent<GraphicRaycaster>().enabled = false;
            GameObject.Find("HealthPoints").GetComponent<GraphicRaycaster>().enabled = false;
            GameObject.Find("Death").GetComponent<GraphicRaycaster>().enabled = false;
            GameObject.Find("HealingRuneCanvas").GetComponent<GraphicRaycaster>().enabled = false;
        }
    }
    void PlaySmokeBlast()
    {
        if(CountPB >= 5 && CountUlt == 0 && CountBB < 9)
        {
            anim.SetInteger("atk_int", 1);
        }
        else if(!anim.GetCurrentAnimatorStateInfo(0).IsName("FogBlast_idle"))
        {
            return;
        }
        else
        {
            return;
        }
    }
    public void RandomPosSmoke()
    {
        smokeBlast.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
    }
    void PlayBlade()
    {
        if(CountPB >= 5)
        {
        }
        else if(CountPB < 5 && CountUlt == 0 && CountBB < 9)
        {
            Debug.Log("not");
            anim.SetInteger("atk_int", 0);
        }
        else if(!anim.GetCurrentAnimatorStateInfo(0).IsName("FogBlast_idle"))
        {
            Debug.Log("ok");
            return;
        }
        
    }
    public void RandomPos()
    {
        CountPB += 1;
        blade.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(350.0f, 470.0f), Random.Range(220.0f, 450.0f), 10.0f));
        blade.transform.rotation = Quaternion.Euler(0.0f,0.0f,Random.Range(0.0f, 360.0f));
    }
    public void Bleeding()
    {
        animation["blood"].normalizedTime += 0.03333f;
        wallCount += 1;
        CountBB += 1;
        if(animation2.GetCurrentAnimatorStateInfo(0).IsName("bloodwall_play"))
        {
            GameObject.Find("Enemy_man").GetComponent<Damage>().GetDamage(15);
        }
    }
    void EnemyUlt()
    {
        if(Blood.rect.width >= 1000)
        {
            anim.SetInteger("atk_int", 5);
            CountUlt += 1;
            anim.SetTrigger("play_ult");
            animation["blood"].normalizedTime = 0.35f;
            animation["blood"].speed = 0.0f;
        }
        else
        {
            return;
        }
    }
    public void EndCount()
    {
        wallCount = 0;
    }
    void BloodWall()
    {
        if(wallCount == 5)
        {
            animation2.SetTrigger("play");
            wallCount = 0;
        }
        if(animation2.GetCurrentAnimatorStateInfo(0).IsName("bloodwall_play") && animation2.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {   
            Debug.Log("h");
            animation2.SetTrigger("return");
        }
    }
    public void NCheck(string a)
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName(a))
        {
            return;
        }
        else
        {
            anim2.SetTrigger("show_atk");
            anim.speed = 0;
        }
    }
    void SpAddition()
    {
        if(GameObject.Find("Enemy_man").GetComponent<Enemy>().Hp_Enemy >= 200)
        {
            if(GameManager.instance.Sp_Player < 100)
            {
                GameManager.instance.Sp_Player += 1;
                GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[1].localScale += new Vector3(0.01f, 0f, 0f);
            }
            else
            {
                return;
            }
        }
        else
        {
            if(GameManager.instance.Sp_Player > 0)
            {
                GameManager.instance.Sp_Player -= 1;
                GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[1].localScale -= new Vector3(0.01f, 0f, 0f);
            }
            else
            {
                return;
            }
        }
    }
    void SwingAudio()
    {
        audioSources[0].Play();
    }
    void BoomAudio()
    {
        audioSources[1].Play();
        CountPB = 0;
    }
    void ExplosionAudio()
    {
        audioSources[2].Play();
    }
    void DamageAudio()
    {
        audioSources[3].Play();
    }
    void BossHurtAudio()
    {
        audioSources[4].Play();
    }
    void BossUltAudio()
    {
        CountUlt = 0;
        anim.ResetTrigger("play_ult");
        audioSources[6].Play();
    }
    void BossUltButtonAudio()
    {
        audioSources[7].Play();
    }
    void BloodBladeAudio()
    {
        audioSources[8].Play();
    }
    void HitAudio()
    {
        audioSources[9].Play();
    }
    void LastAudio()
    {
        audioSources[10].Play();
    }
    public void CancelPlay()
    {
        anim.speed = 0;
    }
    public void StartPlay()
    {
        anim.speed = 1;
    }
    void StartBleeding()
    {
        animation["blood"].speed = 1.0f;
    }
    void BBZero()
    {
        CountBB = 0;
    }
    public void BloodBlade()
    {
        if(CountBB == 9)
        {
            anim.SetInteger("atk_int", 2);
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("bloodblade_movebutton") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                Debug.Log("hi");
                if(GameManager.instance.OnLongClickCount == 0)
                {
                    GameObject.Find("Enemy_man").GetComponent<Damage>().GetDamage(3);
                    GameManager.instance.OnLongClickCount = 0;
                    btns[1].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
                else if(GameManager.instance.OnLongClickCount != 0)
                {
                    GameManager.instance.OnLongClickCount = 0;
                    btns[1].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
            }
            else if(anim.GetCurrentAnimatorStateInfo(0).IsName("bloodblade_movebutton2") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                Debug.Log("hi");
                if(GameManager.instance.OnLongClickCount == 0)
                {
                    GameObject.Find("Enemy_man").GetComponent<Damage>().GetDamage(3);
                    GameManager.instance.OnLongClickCount = 0;
                    btns[2].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
                else if(GameManager.instance.OnLongClickCount != 0)
                {
                    GameManager.instance.OnLongClickCount = 0;
                    btns[2].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
            }
            else if(anim.GetCurrentAnimatorStateInfo(0).IsName("bloodblade_movebutton3") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                if(GameManager.instance.OnLongClickCount == 0)
                {
                    GameObject.Find("Enemy_man").GetComponent<Damage>().GetDamage(3);
                    GameManager.instance.OnLongClickCount = 0;
                    btns[3].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
                else if(GameManager.instance.OnLongClickCount != 0)
                {
                    GameManager.instance.OnLongClickCount = 0;
                    btns[3].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
            }
            else if(anim.GetCurrentAnimatorStateInfo(0).IsName("bloodblade_movebutton4") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                if(GameManager.instance.OnLongClickCount == 0)
                {
                    GameObject.Find("Enemy_man").GetComponent<Damage>().GetDamage(3);
                    GameManager.instance.OnLongClickCount = 0;
                    btns[4].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
                else if(GameManager.instance.OnLongClickCount != 0)
                {
                    GameManager.instance.OnLongClickCount = 0;
                    btns[4].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
            }
            else if(anim.GetCurrentAnimatorStateInfo(0).IsName("bloodblade_movebutton5") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                if(GameManager.instance.OnLongClickCount == 0)
                {
                    GameObject.Find("Enemy_man").GetComponent<Damage>().GetDamage(3);
                    GameManager.instance.OnLongClickCount = 0;
                    btns[5].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
                else if(GameManager.instance.OnLongClickCount != 0)
                {
                    GameManager.instance.OnLongClickCount = 0;
                    btns[5].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
            }
            else if(anim.GetCurrentAnimatorStateInfo(0).IsName("bloodblade_movebutton6") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                if(GameManager.instance.OnLongClickCount == 0)
                {
                    GameObject.Find("Enemy_man").GetComponent<Damage>().GetDamage(3);
                    GameManager.instance.OnLongClickCount = 0;
                    btns[6].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
                else if(GameManager.instance.OnLongClickCount != 0)
                {
                    GameManager.instance.OnLongClickCount = 0;
                    btns[6].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
            }
            else if(anim.GetCurrentAnimatorStateInfo(0).IsName("bloodblade_movebutton7") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                if(GameManager.instance.OnLongClickCount == 0)
                {
                    GameObject.Find("Enemy_man").GetComponent<Damage>().GetDamage(3);
                    GameManager.instance.OnLongClickCount = 0;
                    btns[7].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
                else if(GameManager.instance.OnLongClickCount != 0)
                {
                    GameManager.instance.OnLongClickCount = 0;
                    btns[7].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
            }
            else if(anim.GetCurrentAnimatorStateInfo(0).IsName("bloodblade_movebutton8") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                if(GameManager.instance.OnLongClickCount == 0)
                {
                    GameObject.Find("Enemy_man").GetComponent<Damage>().GetDamage(3);
                    GameManager.instance.OnLongClickCount = 0;
                    btns[8].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
                else if(GameManager.instance.OnLongClickCount != 0)
                {
                    GameManager.instance.OnLongClickCount = 0;
                    btns[8].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50.0f, 750.0f), Random.Range(200.0f, 490.0f), 10.0f));
                }
            }
            else if(anim.GetCurrentAnimatorStateInfo(0).IsName("bloodblade_movebutton9") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                if(GameManager.instance.OnLongClickCount == 0 && a1)
                {
                    GameObject.Find("Enemy_man").GetComponent<Damage>().GetDamage(3);
                    GameManager.instance.OnLongClickCount = 0;
                    a1 = false;
                    CountBB = 0;
                }
                else if(GameManager.instance.OnLongClickCount != 0)
                {
                    GameManager.instance.OnLongClickCount = 0;
                    CountBB = 0;
                }
            }
        }
    }
}
