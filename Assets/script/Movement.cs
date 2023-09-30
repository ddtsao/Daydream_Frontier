using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]GameObject hpPotion_1;
    Vector3 moveDelta;
    BoxCollider2D boxCollider;
    public AudioSource audioSource;
    public GameObject Light;
    public bool InPortal = false;
    int itemAmount = 0;
    float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"); 
        float y = Input.GetAxisRaw("Vertical"); 
        moveDelta = new Vector3(x,y,0);
        if(Light != null)
        {
            if(GameObject.Find("Menu").GetComponent<CharacterMenu>().itemSprite[2].image.sprite != null || GameObject.Find("Menu").GetComponent<ChooseScene>().isLight == true)
            {
                if(x > 0)
                {
                    Light.transform.rotation = Quaternion.Euler(0.0f,0.0f,270f);
                }
                else if(x < 0)
                {
                    Light.transform.rotation = Quaternion.Euler(0.0f,0.0f,90.0f);
                }
                else if(y > 0)
                {
                    Light.transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);
                }
                else if(y < 0)
                {
                    Light.transform.rotation = Quaternion.Euler(0.0f,0.0f,180.0f);
                }
            }
            else if(GameObject.Find("Menu").GetComponent<CharacterMenu>().itemSprite[2].image.sprite == null && GameObject.Find("Menu").GetComponent<ChooseScene>().isLight == false)
            {
                this.transform.GetChild(0).gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 0.3f;
                this.transform.GetChild(0).gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 0.4f;
                this.transform.GetChild(0).gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerAngle = 360.0f;
            }
        }
        if(!InPortal)
        {
            if(moveDelta.x<0)
            {
                transform.localScale = new Vector3(-0.8f,0.65f,1);
            }
            else if(moveDelta.x>0)
            {
                transform.localScale = new Vector3(0.8f,0.65f,1);
            }
            transform.Translate(moveDelta*Time.deltaTime*speed);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name=="Slowdown_Grassfield")
        {
            speed = 0.5f;
        }
        else if(col.gameObject.tag=="hpPotion")
        {
            audioSource.Play();
            Vector3 floatingText_position = transform.position+new Vector3(0.1f,-0.05f,0);
            Vector3 hpPotion_position = transform.position+new Vector3(-0.27f,0,0);
            GameManager.instance.ShowText("+1",25,Color.yellow,floatingText_position,hpPotion_position,Vector3.up*50,1.0f);
            itemAmount += 1;
            GameManager.instance.updateMenu(1, 0);
            Destroy(col.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name=="Slowdown_Grassfield")
        {
            speed = 1f;
        }
    }
}
