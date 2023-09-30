using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;
    public GameObject HpPotion;

    private List<FloatingText> floatingTexts = new List<FloatingText>();
    private List<FloatingText> hpPotions = new List<FloatingText>();

    private void Update()
    {
        foreach(FloatingText txt in floatingTexts)
        {
            txt.UpdateMoveFloat();
        }
        foreach(FloatingText hp_Potion in hpPotions)
        {
            hp_Potion.UpdateMoveFloat();
        }
    }

    public void Show(string msg,int fontSize,Color color,Vector3 floatingText_position,Vector3 hpPotion_position,Vector3 motion,float duration)
    {
        FloatingText floatingText = GetFloatingText();
        FloatingText hpPotion = GetHpPotion();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(floatingText_position);
        floatingText.motion = motion;
        floatingText.duration = duration;
        hpPotion.go.transform.position = Camera.main.WorldToScreenPoint(hpPotion_position);
        hpPotion.motion = motion;
        hpPotion.duration = duration;
        hpPotion.Show();
        floatingText.Show();
    }

    public void ShowTxt(string msg,int fontSize,Color color,FontStyles fontStyle,Vector3 floatingText_position,Vector3 motion,float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.txt.fontStyle = fontStyle;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(floatingText_position);
        floatingText.motion = motion;
        floatingText.duration = duration;
        floatingText.Show();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);
        if(txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<TextMeshProUGUI>();
            
            floatingTexts.Add(txt);
        }
        return txt;
    }

    private FloatingText GetHpPotion()
    {
        FloatingText hp_Potion = hpPotions.Find(t => !t.active);
        if(hp_Potion == null)
        {
            hp_Potion = new FloatingText();
            hp_Potion.go = Instantiate(HpPotion);
            hp_Potion.go.transform.SetParent(textContainer.transform);
            hp_Potion.hp_Potion = hp_Potion.go.GetComponent<Image>();
            
            hpPotions.Add(hp_Potion);
        }
        return hp_Potion;
    }
}
