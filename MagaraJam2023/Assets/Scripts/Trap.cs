using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.Instance.Damage(Damage);
            Destroy(gameObject);
        }
    }
}
