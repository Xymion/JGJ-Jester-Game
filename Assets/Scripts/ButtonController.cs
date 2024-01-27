using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer SR;

    public Sprite defaultImg;
    public Sprite pressedImg;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        { 
            SR.sprite = pressedImg;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            SR.sprite = defaultImg;
        }
    }
}
