using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Random = System.Random;

public class arrows : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject circlepref;
    public List<GameObject> comingmoves = new List<GameObject>();
    private Random rand = new Random();
    private float[] arrowspositions = { 4, 5.5f, 7, 8.5f };
    public TextMeshProUGUI ScoreTextMeshPro;
    public int scorevalue = 0;
    public float horizontalInput;
    public float verticalInput;
    private float arrowmaxpos = 2.6f;
    public TextMeshProUGUI arrLeftTextMeshPro;
    public TextMeshProUGUI arrRightTextMeshPro;
    public TextMeshProUGUI arrUpTextMeshPro;
    public TextMeshProUGUI arrDownTextMeshPro;
    public TextMeshProUGUI missTextMeshPro;
    public TextMeshProUGUI perfectTextMeshPro;
    public TextMeshProUGUI almostTextMeshPro;
    public int misscount = 0;
    public int perfectcount = 0;
    public int almostcount = 0;
    float delayforarr = 0;
    public float delayconstant = 0.5f;
    public TextMeshProUGUI kingBubbleTextMeshProUGUI;
    public TextMeshProUGUI jesterbubbleTextMeshProUGUI;
    private float delaybubbleconstant = 10f;
    private float delaybubble = 5;
    private string[] words = { "imdumb", "loveking", "moveforking" };
    private string currentword = "";
    private string lastinputs = "";


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //delayconstant = Math.Max(0.3f, delayconstant - 0.00001f);
        delayforarr = Math.Max(0, delayforarr - Time.deltaTime);
        delaybubble = Math.Max(0, delaybubble - Time.deltaTime);
        arrUpTextMeshPro.fontSize = 36;
        arrDownTextMeshPro.fontSize = 36;
        arrLeftTextMeshPro.fontSize = 36;
        arrRightTextMeshPro.fontSize = 36;
        lastinputs += Input.inputString;
        jesterbubbleTextMeshProUGUI.text = lastinputs;
        bool typingright = !(lastinputs.Length < currentword.Length);
        bool mistake = false;
        for (int i = 0; i < currentword.Length && i < lastinputs.Length; i++)
        {
            if (lastinputs[i] != currentword[i])
            {
                typingright = false;
                mistake = true;
            }
        }

        if (typingright)
        {
            kingBubbleTextMeshProUGUI.text = "Good job jester!";
        }

        if (mistake)
        {
            kingBubbleTextMeshProUGUI.text = "You're disappointing";
        }
        
        //scorevalue++;
        ScoreTextMeshPro.text = "Score : " + scorevalue.ToString();
        if (delayforarr == 0)
        {
            delayforarr = delayconstant;
            comingmoves.Add(Instantiate(circlepref, new Vector3(arrowspositions[rand.Next(0,4)], -6, 0), Quaternion.identity));
        }

        if (delaybubble == 0)
        {
            lastinputs = String.Empty;
            delaybubble = delaybubbleconstant;
            string tmp = words[rand.Next(0, words.Length)];
            while (tmp == currentword)
            {
                tmp = words[rand.Next(0, words.Length)];
            }

            currentword = tmp;
            kingBubbleTextMeshProUGUI.text = "SAY : " + currentword + " !";
        }
        
        foreach (var el in comingmoves)
        {
            var pos = el.transform.position;
            el.transform.position = new Vector3(pos.x, (float)(pos.y + 0.01), pos.z);
            if (pos.y > arrowmaxpos)
            {
                misscount++;
                missTextMeshPro.text = "Misses : " + misscount.ToString();
                comingmoves.Remove(el);
                Destroy(el);
                //scorevalue -= 50;
            }
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        InputManager();
        
        horizontalInput = 0;
        verticalInput = 0;
    }

    private void InputManager()
    {
        if (verticalInput > 0)
        {
            arrUpTextMeshPro.fontSize = 50;
            var arr = comingmoves[0];
            if (comingmoves[0].transform.position.x == 7)
            {
                if (arrowmaxpos - arr.transform.position.y < 0.5) //perfect timing
                {
                    scorevalue += 50;
                    comingmoves.Remove(arr);
                    Destroy(arr);
                    perfectcount++;
                    perfectTextMeshPro.text = "Perfect : " + perfectcount.ToString();
                }
                else if (arrowmaxpos - arr.transform.position.y < 1) //bad timing but still close
                {
                    scorevalue += (int) (50 * (1 - (arrowmaxpos - arr.transform.position.y)));
                    comingmoves.Remove(arr);
                    Destroy(arr);
                    almostcount++;
                    almostTextMeshPro.text = "Almost : " + almostcount.ToString();
                }
            }
        }
        if (verticalInput < 0)
        {
            arrDownTextMeshPro.fontSize = 50;
            var arr = comingmoves[0];
            if (comingmoves[0].transform.position.x == 5.5f)
            {
                if (arrowmaxpos - arr.transform.position.y < 0.3) //perfect timing
                {
                    scorevalue += 50;
                    comingmoves.Remove(arr);
                    Destroy(arr);
                    perfectcount++;
                    perfectTextMeshPro.text = "Perfect : " + perfectcount.ToString();
                }
                else if (arrowmaxpos - arr.transform.position.y < 0.6) //bad timing but still close
                {
                    scorevalue += (int) (50 * (1 - (arrowmaxpos - arr.transform.position.y)));
                    comingmoves.Remove(arr);
                    Destroy(arr);
                    almostcount++;
                    almostTextMeshPro.text = "Almost : " + almostcount.ToString();
                }
            }
        }
        if (horizontalInput > 0)
        {
            arrRightTextMeshPro.fontSize = 50;
            var arr = comingmoves[0];
            if (comingmoves[0].transform.position.x == 8.5f)
            {
                if (arrowmaxpos - arr.transform.position.y < 0.3) //perfect timing
                {
                    scorevalue += 50;
                    comingmoves.Remove(arr);
                    Destroy(arr);
                    perfectcount++;
                    perfectTextMeshPro.text = "Perfect : " + perfectcount.ToString();
                }
                else if (arrowmaxpos - arr.transform.position.y < 0.6) //bad timing but still close
                {
                    scorevalue += (int) (50 * (1 - (arrowmaxpos - arr.transform.position.y)));
                    comingmoves.Remove(arr);
                    Destroy(arr);
                    almostcount++;
                    almostTextMeshPro.text = "Almost : " + almostcount.ToString();
                }
            }
        }
        if (horizontalInput < 0)
        {
            arrLeftTextMeshPro.fontSize = 50;
            var arr = comingmoves[0];
            if (comingmoves[0].transform.position.x == 4)
            {
                if (arrowmaxpos - arr.transform.position.y < 0.3) //perfect timing
                {
                    scorevalue += 50;
                    comingmoves.Remove(arr);
                    Destroy(arr);
                    perfectcount++;
                    perfectTextMeshPro.text = "Perfect : " + perfectcount.ToString();
                }
                else if (arrowmaxpos - arr.transform.position.y < 0.6) //bad timing but still close
                {
                    scorevalue += (int) (50 * (1 - (arrowmaxpos - arr.transform.position.y)));
                    comingmoves.Remove(arr);
                    Destroy(arr);
                    almostcount++;
                    almostTextMeshPro.text = "Almost : " + almostcount.ToString();
                }
            }
        }
    }
}
