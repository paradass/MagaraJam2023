using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public float Health, MovementSpeed, RotationSpeed,AttackSpeed;
    public GameObject[] Objects;
    public AudioSource[] Sounds;

    [System.NonSerialized] public int WheelCount;

    float attackTimer;
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
        Attack();
    }

    void Ui()
    {
        healthBar.value = Health;

        if (Health <= 0) SceneManager.LoadScene(0);
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal")*RotationSpeed*Time.deltaTime;
        float vertical = Input.GetAxis("Vertical")* MovementSpeed * Time.deltaTime;

        transform.Rotate(new Vector3(0, horizontal, 0));
        transform.Translate(new Vector3(0, 0, vertical));

        if(transform.position.y < -2 || Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(0);
    }

    void Interact()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward,out hit, 5) && hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
            {
                interactable.Interact();
            }
        }
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.Tab) && Time.time >= attackTimer)
        {
            if (!Sounds[2].isPlaying) Sounds[2].Play();
            attackTimer = Time.time+AttackSpeed;
            Destroy(Instantiate(Objects[2], Objects[1].transform.position, transform.rotation), 5);
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
