using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Machine : Interactable
{
    public static Machine Instance;
    public int WheelCount;
    public TextMeshPro WheelText;

    private void Awake()
    {
        Instance = this;
    }

    public override void Interact()
    {
        WheelCount += Player.Instance.WheelCount;
        WheelText.text = " x " + (5 - WheelCount).ToString();
        Player.Instance.DelWheel(Player.Instance.WheelCount);

        if (WheelCount >= 5) SceneManager.LoadScene(1);

        transform.GetChild(0).GetComponent<Interactable>().Interact();
    }
}
