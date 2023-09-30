using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
   public GameObject enemy;
   public RectTransform bar;
   public float[] hp;
   float h;

   private void Start()
   {
      
   }
   private void Update()
   {
      UpdateHpBar();
   }
   public void UpdateHpBar()
   {
      if(enemy.GetComponent<Enemy>().Hp_Enemy < 0)
      {
         bar.localScale = new Vector3(0f, 1f, 1f);
      }
      else if(enemy.GetComponent<Enemy>().Hp_Enemy == 0)
      {
         bar.localScale = new Vector3(0f, 1f, 1f);
      }
      else
      {
         h = (enemy.GetComponent<Enemy>().Hp_Enemy*1.0f)/hp[0];
         bar.localScale = new Vector3(h, 1f, 1f);
      }
   }
}


