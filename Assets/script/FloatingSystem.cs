using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingSystem : MonoBehaviour
{
    [SerializeField]GameObject Panel_hpPotion;
    Vector3 character_position;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name=="item_hpPotion")
        {
            UpdateMoveFloat();
        }
    } 
    void UpdateMoveFloat()
    {
        character_position = this.transform.position;
        Panel_hpPotion.SetActive(true);
        Panel_hpPotion.transform.position+=Camera.main.WorldToScreenPoint(character_position)*Time.deltaTime*10f;
    }
}
