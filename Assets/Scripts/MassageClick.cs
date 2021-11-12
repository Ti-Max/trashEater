using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassageClick : MonoBehaviour
{
    public Plot plot;
    private void Start()
    {
        plot = FindObjectOfType<Plot>();
    }
    private void OnMouseUpAsButton()
    {
        plot.NextMessage();
    }
}
