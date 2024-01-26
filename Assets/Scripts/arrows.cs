using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class arrows : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject circlepref;
    public List<GameObject> comingmoves = new List<GameObject>();
    private Random rand = new Random();
    private float[] arrowspositions = { 4, 5.5f, 7, 8.5f };
    public GameObject ScoreTextMeshPro;

    void Start()
    {
        comingmoves.Add(Instantiate(circlepref, new Vector3(4, 0, 0), Quaternion.identity));
        comingmoves.Add(Instantiate(circlepref, new Vector3(5.5f, -1, 0), Quaternion.identity));
        comingmoves.Add(Instantiate(circlepref, new Vector3(7, -2, 0), Quaternion.identity));
        comingmoves.Add(Instantiate(circlepref, new Vector3(8.5f, -3, 0), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (comingmoves.Count < 2)
        {
            comingmoves.Add(Instantiate(circlepref, new Vector3(arrowspositions[rand.Next(0,3)], -3, 0), Quaternion.identity));
        }
        foreach (var el in comingmoves)
        {
            var pos = el.transform.position;
            if (pos.y > 2.5)
            {
                comingmoves.Remove(el);
                Destroy(el);
            }
            el.transform.position = new Vector3(pos.x, (float)(pos.y + 0.01), pos.z);
        }
    }
}
