using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testicontroller : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Transform movePoint;

    public float cooldownTime = 0.05f;
    private bool isCooldown = false;

    public LayerMask stopMovement;

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

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Input.GetKey(KeyCode.D) && !isCooldown)
            {
                StartCoroutine(Cooldown());
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, stopMovement))
                {
                    movePoint.position += new Vector3(1.0f, 0f, 0f);
                }

            }
            else if (Input.GetKey(KeyCode.A) && !isCooldown)
            {
                StartCoroutine(Cooldown());
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, stopMovement))
                {
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                }

            }
            if (Input.GetKey(KeyCode.W) && !isCooldown)
            {
                StartCoroutine(Cooldown());
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, stopMovement))
                {
                    movePoint.position += new Vector3(0f, 1f, 0f);
                }

            }
            else if (Input.GetKey(KeyCode.S) && !isCooldown)
            {
                StartCoroutine(Cooldown());
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, stopMovement))
                {
                    movePoint.position += new Vector3(0f, -1f, 0f);
                }

            }


        }
    }

    public IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
