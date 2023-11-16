using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public float Health, MovementSpeed, RotationSpeed;

    public AudioSource[] Sounds;

    Slider healthBar;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
    }

    private void Update()
    {
        Ui();
        Movement();
    }

    void Ui()
    {
        healthBar.value = Health;
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal")*RotationSpeed*Time.deltaTime;
        float vertical = Input.GetAxis("Vertical")* MovementSpeed * Time.deltaTime;

        transform.Rotate(new Vector3(0, horizontal, 0));
        transform.Translate(new Vector3(0, 0, vertical));
    }

    public void Damage(float damage)
    {
        Sounds[0].Play();
        Health -= damage;
    }
    
    public void Heal(float heal)
    {
        Health += heal;
    }
}
