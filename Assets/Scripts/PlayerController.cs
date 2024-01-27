using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Transform movePoint;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, MoveSpeed * Time.deltaTime);
        //Only WASD movement not arrowkeys

        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
        if (Input.GetKey(KeyCode.D))
            {
                movePoint.position += new Vector3(1f, 0f, 0f);
            }
        else if (Input.GetKey(KeyCode.A))
            {
                movePoint.position += new Vector3(-1f, 0f, 0f);
            }
        if (Input.GetKey(KeyCode.W))
            {
                movePoint.position += new Vector3(0f, 1f, 0f);
            }
        else if (Input.GetKey(KeyCode.S))
            {
                movePoint.position += new Vector3(0f, -1f, 0f);
            }


        }
    }
}
