using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public FloatingTextManager floatingTextManager;
    public List<Sprite> itemSprites;
    public CharacterMenu characterMenu;
    public int Hp_Player = 20;
    public int Sp_Player = 50;
    public int OnLongClickCount = 0;//時機對到了
    private void Awake()
    {
        instance = this;
        Hp_Player = 20;
        Sp_Player = 50;
    }
    void Start() 
    {
        if(Hp_Player == 0)
        {
            Hp_Player = 20;
        }
        if(Sp_Player == 0)
        {
            Sp_Player = 50;
        }
        PlayerPrefs.DeleteAll();
    }
    public void ShowText(string msg,int fontSize,Color color,Vector3 floatingText_position,Vector3 hpPotion_position,Vector3 motion,float duration)
    {
        floatingTextManager.Show(msg,fontSize,color,floatingText_position,hpPotion_position,motion,duration);
    }
    public void showTxt(string msg,int fontSize,Color color,FontStyles fontStyle,Vector3 floatingText_position,Vector3 motion,float duration)
    {
        floatingTextManager.ShowTxt(msg,fontSize,color,fontStyle,floatingText_position,motion,duration);
    }
    public void updateMenu(int m, int n)
    {
        characterMenu.UpdateMenuHp(m, n);
    }
    public void updateMenuSp(int m, int n)
    {
        characterMenu.UpdateMenuSp(m, n);
    }
    public void updateMenuItem(int m, int n)
    {
        characterMenu.UpdateMenuItem(m, n);
    }
    public void updateMenuSkill(int m,int n)
    {
        characterMenu.UpdateMenuSkill(m,n);
    }
}
