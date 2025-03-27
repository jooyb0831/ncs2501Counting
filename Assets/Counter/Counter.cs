using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public GameObject ballsParent;
    public Transform[] balls;
    private int Count = 0;

    private void Start()
    {
        BallSet();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && balls != null)
        {
            RePos();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
    }

    void RePos()
    {
        Count = 0;
        CounterText.text = "Count : " + Count;
        foreach (var item in balls)
        {
            //item.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.position = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(12.0f, 13.0f), Random.Range(-3.5f, 3.5f));

        }
    }

    void BallSet()
    {

        balls = ballsParent.GetComponentsInChildren<Transform>();
        foreach (var item in balls)
        {
            item.transform.position = new Vector3(item.transform.position.x + Random.Range(-1f, 1f), 12.63f, item.transform.position.z + Random.Range(-1f, 1f));
        }
    }
}
