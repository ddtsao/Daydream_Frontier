using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterMenu : MonoBehaviour
{
    public TextMeshProUGUI HealthPoint;
    public List<TextMeshProUGUI> ItemAmount;
    public List<Button> itemSprite;
    public List<Button> skillSprite;
    public List<RectTransform> HealthPointBar;
    public List<string> Triggers;
    public Animator animator;
    public int HpPotionAmount = 0;
    public int SpPotionAmount = 0;
 
    public void UpdateMenuHp(int m, int n)
    {
        HpPotionAmount += m;
        itemSprite[n].image.sprite = GameManager.instance.itemSprites[n];
        itemSprite[n].GetComponent<Image>().color = new Color(255f/255f,255f/255f,255f/255f,255f/255f);
        ItemAmount[n].text = HpPotionAmount.ToString();
    }
    public void UpdateMenuSp(int m, int n)
    {  
        SpPotionAmount += m;
        itemSprite[n].image.sprite = GameManager.instance.itemSprites[n];
        itemSprite[n].GetComponent<Image>().color = new Color(255f/255f,255f/255f,255f/255f,255f/255f);
        ItemAmount[n].text = SpPotionAmount.ToString();
    }
    public void UpdateMenuItem(int m, int n)
    {
        itemSprite[m].image.sprite = GameManager.instance.itemSprites[n];
        itemSprite[m].GetComponent<Image>().color = new Color(255f/255f,255f/255f,255f/255f,255f/255f);
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("menu_showing"))
        {
            return;
        }
        if(itemSprite[m].image.sprite != null)
        {
            animator.SetTrigger(Triggers[m]);
        }
    }
    public void UpdateMenuSkill(int m,int n)
    {
        skillSprite[m].image.sprite = GameManager.instance.itemSprites[n];
        skillSprite[m].GetComponent<Image>().color = new Color(255f/255f,255f/255f,255f/255f,255f/255f);
    }
    public void AddHp()
    {
        if(HpPotionAmount == 0)
        {
            return;
        }

        if(GameManager.instance.Hp_Player > 100)
        {
            return;
        }
        else if(GameManager.instance.Hp_Player == 100)
        {
            GameManager.instance.Hp_Player = 100;
            HealthPointBar[0].localScale = Vector3.one;
            ItemAmount[0].text = HpPotionAmount.ToString();
        }
        else if(100 - GameManager.instance.Hp_Player >= 10)
        {
            HealthPointBar[0].localScale += new Vector3(0.1f,0,0);
            GameManager.instance.Hp_Player += 10;
            HpPotionAmount -=1;
            ItemAmount[0].text = HpPotionAmount.ToString();
        }
        else if(0 <= 100 - GameManager.instance.Hp_Player | 100 - GameManager.instance.Hp_Player <= 10)
        {
            GameManager.instance.Hp_Player = 100;
            HealthPointBar[0].localScale = Vector3.one;
            HpPotionAmount -= 1;
            ItemAmount[0].text = HpPotionAmount.ToString();
        }
    }  
    public void AddSp()
    {
        if(SpPotionAmount == 0)
        {
            return;
        }

        if(GameManager.instance.Sp_Player == 100)
        {
            GameManager.instance.Sp_Player = 100;
            HealthPointBar[1].localScale = Vector3.one;
            ItemAmount[1].text = SpPotionAmount.ToString();
        }
        else if(100 - GameManager.instance.Sp_Player >= 15)
        {
            HealthPointBar[1].localScale += new Vector3(0.15f,0,0);
            GameManager.instance.Sp_Player += 15;
            SpPotionAmount -=1;
            ItemAmount[1].text = SpPotionAmount.ToString();
        }
        else if(0 <= 100 - GameManager.instance.Sp_Player | 100 - GameManager.instance.Sp_Player <= 15)
        {
            GameManager.instance.Sp_Player = 100;
            HealthPointBar[1].localScale = Vector3.one;
            SpPotionAmount -= 1;
            ItemAmount[1].text = SpPotionAmount.ToString();
        }
    }
    public void AddRuneHp()
    {
        HealthPointBar[0].localScale = Vector3.one;
        HealthPointBar[2].localScale = Vector3.one;
        GameManager.instance.Hp_Player = 120;
    }
}