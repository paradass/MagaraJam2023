using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : Interactable
{
    public static Machine Instance;

    public int WheelCount;

    private void Awake()
    {
        Instance = this;
    }

    public override void Interact()
    {
        WheelCount += Player.Instance.WheelCount;
        Player.Instance.DelWheel(Player.Instance.WheelCount);

        transform.GetChild(0).GetComponent<Interactable>().Interact();
    }
}
