using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleChanger : Interactable
{
    public float SubtitleTime;
    [TextArea(5, 5)] public string SubtitleText;

    public override void Interact()
    {
        Subtitle.Instance.Print(SubtitleText, SubtitleTime);
    }
}
