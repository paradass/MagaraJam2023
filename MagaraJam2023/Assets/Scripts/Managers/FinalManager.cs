using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalManager : MonoBehaviour
{
    [TextArea(3, 3)] public string[] Texts;
    public float[] Times;

    TextMeshPro text;

    private void Start()
    {
        text = GameObject.Find("FinalText").GetComponent<TextMeshPro>();

        StartCoroutine(Print());
    }

    IEnumerator Print()
    {
        for(int i = 0; i < Texts.Length; i++)
        {
            text.text = Texts[i];
            yield return new WaitForSeconds(Times[i]);
        }
    }
}
