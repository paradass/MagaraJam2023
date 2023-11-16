using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamObject : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
