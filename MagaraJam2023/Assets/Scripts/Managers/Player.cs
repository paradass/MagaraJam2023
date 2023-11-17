using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public float Health, MovementSpeed, RotationSpeed;
    public GameObject[] Objects;
    public AudioSource[] Sounds;

    [System.NonSerialized] public int WheelCount;

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
        Interact();
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

    void Interact()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward,out hit, 8) && hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
            {
                interactable.Interact();
            }
        }
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

    public void AddWheel(int count)
    {
        Sounds[1].Play();
        WheelCount += count;
        Objects[0].SetActive(true);
    }

    public void DelWheel(int count)
    {
        WheelCount -= count;
        Objects[0].SetActive(false);
    }
}
