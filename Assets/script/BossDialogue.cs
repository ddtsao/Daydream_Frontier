using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossDialogue : MonoBehaviour
{
    public TextMeshProUGUI texts;
    public TextMeshProUGUI name;
    public TextMeshProUGUI button1;
    public TextMeshProUGUI button2;

    public List<string> LinesPartOne;
    public List<string> LinesPartTwo;
    public List<string> LinesPartThree;
    public List<string> LinesPartFour;
    public List<string> LinesPartFive;
    public List<GameObject> buttons;
    public List<GameObject> TurnOn;
    public List<Animator> anim;
    public List<Animation> anim_blood;
    public List<AudioSource> As;
    public int index = 0;
    public int c = 0;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        anim_blood[0]["blood"].speed = 0.0f;
        if(anim[0].GetCurrentAnimatorStateInfo(0).IsName("fall") && anim[0].GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            TurnOn[0].SetActive(true);
            TurnOn[1].SetActive(true);
            TurnOn[2].SetActive(true);
            TurnOn[3].SetActive(true);
            StartDialogue(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(anim[0].GetCurrentAnimatorStateInfo(0).IsName("fall") && anim[0].GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            if(!TurnOn[0].activeSelf)
            {
                TurnOn[0].SetActive(true);
                TurnOn[1].SetActive(true);
                TurnOn[2].SetActive(true);
                TurnOn[3].SetActive(true);
                StartDialogue(1);
            }
        }
        CheckLines();
    }
    public void StartDialogue(int n)
    {
        switch (n)
        {
            case 1:
                StartCoroutine(TypeLine());
                break;
            
            case 2:
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                c += 1;
                StartCoroutine(TypeLineTwo());;
                break;

            case 3:
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                c += 2;
                StartCoroutine(TypeLineThree());
                break;
                
            case 4:
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                buttons[2].SetActive(false);
                buttons[3].SetActive(false);
                buttons[4].SetActive(false);
                c = 3;
                StartCoroutine(TypeLineFour());
                break;
            case 5:
                buttons[3].SetActive(false);
                buttons[4].SetActive(false);
                c = 4;
                StartCoroutine(TypeLineFive());
                break;    

            default:
                
                break;
        }
    }
    public void CheckLines()
    {
        if(anim[0].GetCurrentAnimatorStateInfo(0).IsName("fall") && anim[0].GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            if(Input.GetMouseButtonDown(0))
            {
                switch (c)
                {
                    case 0:
                        if(texts.text == LinesPartOne[index])
                        {
                            if(texts.text == "還有呼吸嗎!?")
                            {
                                buttons[0].SetActive(true);
                                buttons[1].SetActive(true);
                                index = 0;
                            }
                            else
                            {
                                As[2].Play();
                                StartCoroutine(NextLine());
                            }
                        }
                        else if(texts.text == LinesPartOne[LinesPartOne.Count - 1])
                        {
                            return;
                        }
                        else
                        {
                            As[2].Play();
                            StopAllCoroutines();
                            texts.text = LinesPartOne[index];
                        }
                        break;
                    case 1:
                        if(texts.text == LinesPartTwo[index])
                        {
                            if(texts.text == "他似乎說了些什麼!")
                            {
                                buttons[2].SetActive(true);
                                button1.text = "仔細聆聽";
                                index = 0;
                            }
                            else
                            {
                                As[2].Play();
                                StartCoroutine(NextLineTwo());
                            }
                        }
                        else if(texts.text == LinesPartTwo[LinesPartTwo.Count - 1])
                        {
                            return;
                        }
                        else
                        {
                            As[2].Play();
                            StopAllCoroutines();
                            texts.text = LinesPartTwo[index];
                        }
                        break;
                    case 2:
                        if(texts.text == LinesPartThree[index])
                        {
                            if(texts.text == "糟了，「症狀」正在逐漸加深")
                            {
                                buttons[3].SetActive(true);
                                buttons[4].SetActive(true);
                                index = 0;
                            }
                            else
                            {
                                As[2].Play();
                                StartCoroutine(NextLineThree());
                            }
                        }
                        else if(texts.text == LinesPartThree[LinesPartThree.Count - 1])
                        {
                            return;
                        }
                        else
                        {
                            As[2].Play();
                            StopAllCoroutines();
                            texts.text = LinesPartThree[index];
                        }
                        break;
                    case 3:
                        if(texts.text == LinesPartFour[index])
                        {
                            if(texts.text == "#fwuck#DE不要靠近我!!!!!!!!!!!!!!")
                            {
                                anim_blood[0]["blood"].speed = 1.0f;
                                anim[0].SetTrigger("start");
                                As[0].mute = true;
                                As[1].Play();
                                this.gameObject.SetActive(false);
                                TurnOn[4].SetActive(true);
                            }
                            else
                            {
                                As[2].Play();
                                StartCoroutine(NextLineFour());
                            }
                        }
                        else
                        {
                            As[2].Play();
                            StopAllCoroutines();
                            texts.text = LinesPartFour[index];
                        }
                        break;
                    case 4:
                        if(texts.text == LinesPartFive[index])
                        {
                            if(texts.text == "快做好準備!")
                            {
                                anim_blood[0]["blood"].speed = 1.0f;
                                anim[0].SetTrigger("start");
                                As[0].mute = true;
                                As[1].Play();
                                this.gameObject.SetActive(false);
                                TurnOn[4].SetActive(true);
                            }
                            else
                            {
                                As[2].Play();
                                StartCoroutine(NextLineFive());
                            }
                        }
                        else
                        {
                            As[2].Play();
                            StopAllCoroutines();
                            texts.text = LinesPartFive[index];
                        }
                        break;        
                    default:
                        break;
                }
            }
        }
    }
    IEnumerator TypeLine()
    {
        foreach (char c in LinesPartOne[index].ToCharArray())
        {
            if(index == 1)
            {
                name.text = "皢銘";
            }
            else if(index == 4)
            {
                name.text = "「墜樓者」";
            }
            else
            {
                name.text = "我";
            }
            texts.text += c;
            yield return new WaitForSeconds(speed);
        }
    }
    IEnumerator TypeLineTwo()
    {
        texts.text = string.Empty;
        foreach (char c in LinesPartTwo[index].ToCharArray())
        {
            if(index == 3)
            {
                name.text = "皢銘";
            }
            else if(index == 1 || index == 5)
            {
                name.text = "「墜樓者」";
            }
            else
            {
                name.text = "我";
            }
            texts.text += c;
            yield return new WaitForSeconds(speed);
        }
    }
    IEnumerator TypeLineThree()
    {
        
        texts.text = string.Empty;
        foreach (char c in LinesPartThree[index].ToCharArray())
        {
            texts.text += c;
            yield return new WaitForSeconds(speed);
        }
    }
    IEnumerator TypeLineFour()
    {
        texts.text = string.Empty;
        foreach (char c in LinesPartFour[index].ToCharArray())
        {
            if(index == 0 || index == 7)
            {
                name.text = "皢銘";
            }
            else if(index == 1 || index == 3 || index == 6 || index == 15)
            {
                name.text = "「墜樓者」";
            }
            else
            {
                name.text = "我";
            }
            texts.text += c;
            yield return new WaitForSeconds(speed);
        }
    }
    IEnumerator TypeLineFive()
    {
        texts.text = string.Empty;
        foreach (char c in LinesPartFive[index].ToCharArray())
        {
            if(index == 8 || index == 9)
            {
                name.text = "皢銘";
            }
            else
            {
                name.text = "我";
            }
            texts.text += c;
            yield return new WaitForSeconds(speed);
        }
    }
    IEnumerator NextLine()
    {   
        if(texts.text == LinesPartOne[LinesPartOne.Count - 1])
        {
            yield return null;
        }
        else if(index < LinesPartOne.Count - 1)
        {
            index += 1;
            texts.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            texts.text = string.Empty;
            index = 0;
        }
        yield return null;
    }
    IEnumerator NextLineTwo()
    {   
        if(texts.text == LinesPartTwo[LinesPartTwo.Count - 1])
        {
            yield return null;
        }
        else if(index < LinesPartTwo.Count - 1)
        {
            index += 1;
            texts.text = string.Empty;
            StartCoroutine(TypeLineTwo());
        }
        else
        {
            texts.text = string.Empty;
            index = 0;
        }
        yield return null;
    }
    IEnumerator NextLineThree()
    {   
        if(texts.text == LinesPartThree[LinesPartThree.Count - 1])
        {
            yield return null;
        }
        else if(index < LinesPartThree.Count - 1)
        {
            index += 1;
            texts.text = string.Empty;
            StartCoroutine(TypeLineThree());
        }
        else
        {
            texts.text = string.Empty;
            index = 0;
        }
        yield return null;
    }
    IEnumerator NextLineFour()
    {   
        if(index < LinesPartFour.Count - 1)
        {
            index += 1;
            texts.text = string.Empty;
            StartCoroutine(TypeLineFour());
        }
        else
        {
            texts.text = string.Empty;
            index = 0;
        }
        yield return null;
    }
    IEnumerator NextLineFive()
    {   
        if(index < LinesPartFive.Count - 1)
        {
            index += 1;
            texts.text = string.Empty;
            StartCoroutine(TypeLineFive());
        }
        else
        {
            texts.text = string.Empty;
            index = 0;
        }
        yield return null;
    }
}
