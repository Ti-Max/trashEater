using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFloating : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponentInChildren<Animator>().speed = Random.Range(0.5f, 1.2f);
        }
    }
}
