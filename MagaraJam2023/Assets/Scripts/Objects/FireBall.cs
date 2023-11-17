using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.Translate(new Vector3(0, 0, Speed*Time.deltaTime));
    }
}
