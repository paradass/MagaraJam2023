using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class Subtitle : MonoBehaviour
{
    public static Subtitle Instance;
    public TextMeshProUGUI SubtitleText;
    public GameObject SubtitleBackground;

    private void Awake()
    {
        Instance = this;
    }

    public void Print(string text,float time)
    {
        CancelInvoke("Close");
        Invoke("Close", time);

        SubtitleText.text = text;
        SubtitleBackground.SetActive(true);
    }

    void Close()
    {
        SubtitleText.text = "";
        SubtitleBackground.SetActive(false);
    }
}
