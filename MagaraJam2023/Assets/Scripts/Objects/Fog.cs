using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.position = Player.Instance.transform.position;
    }
}
