using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleSkill : MonoBehaviour
{
    public Animator anim;
    CharacterMenu characterMenu;
    public List<Button> BattleSkills;
    public List<RectTransform> Flags;
    public void AddSkill(int m,int n)
    {
        if(GameObject.Find("Menu").GetComponent<CharacterMenu>().itemSprite[m].GetComponent<Image>().sprite != null)
        {
            if(BattleSkills[0].image.sprite == null)
            {
                BattleSkills[0].image.sprite = GameManager.instance.itemSprites[n];
                BattleSkills[0].GetComponent<Image>().color = new Color(255f/255f,255f/255f,255f/255f,255f/255f);
            }
        }
    }
    public void GetSpDamage(int n)
    {
        GameManager.instance.Sp_Player -= n;
        if(GameManager.instance.Sp_Player > 100)
        {
            float dmg = n/20f;
            GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[2].localScale -= new Vector3(dmg, 0f, 0f);
        }
        else if(GameManager.instance.Sp_Player < 100)
        {
            if(GameManager.instance.Sp_Player > 0)
            {
                float dmg = n/100f;
                GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[1].localScale -= new Vector3(dmg, 0f, 0f);
            }
            else if(GameManager.instance.Sp_Player <= 0)
            {
                GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[1].localScale = Vector3.zero;
            }
        }
        else if(GameManager.instance.Sp_Player == 100)
        {
            GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[1].localScale = Vector3.one;
        }
    }
    public void ActivateSkill()
    {
        if(GameManager.instance.Sp_Player < 75 || anim.GetCurrentAnimatorStateInfo(0).IsName("Introduce") || anim.GetCurrentAnimatorStateInfo(0).IsName("start"))
        {
            Flags[0].localScale = new Vector3(1f, 1f, 1f);
        }
        else if(GameManager.instance.Sp_Player >= 75)
        {
            Flags[0].localScale = new Vector3(0f, 0f, 0f);
        }
        if(Flags[1] != null)
        {
            if(GameManager.instance.Sp_Player < 25)
            {
                Flags[1].localScale = new Vector3(1f, 1f, 1f);
            }
            else if(GameManager.instance.Sp_Player >= 25)
            {
                Flags[1].localScale = new Vector3(0f, 0f, 0f);
            }
        }
    }
    private void Start()
    {
        AddSkill(2, 2);
    }
    private void Update()
    {
        ActivateSkill();
    }
}
