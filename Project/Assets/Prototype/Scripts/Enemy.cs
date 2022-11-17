using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public string character_name;
    public float character_hp, character_speed, character_acceleration, character_angular_speed, character_range, character_dammage, character_cooldown;
    public bool isAlive, instantiaiteBlood;
    public float timer;

    NavMeshAgent navMeshAgent;

    public GameObject player;
    public Rigidbody rb;

    public AudioSource audioSource;
    public AudioClip clip; 

    [SerializeField] private GameObject blood;

    public Animator anim;

    public GameObject coin;
    public GameObject box;
    public static bool boxAvailable = true;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();   
    }

    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        rb = GetComponent<Rigidbody>();
        
        character_name = "Dagger";
        character_hp = 100;
        character_speed = 6;
        character_acceleration = 40;
        character_angular_speed = 300;
        character_range = 2f;
        character_dammage = 20;
        character_cooldown = 3f;
        timer = character_cooldown;
        setCharacter();
        isAlive = true;
        instantiaiteBlood = true;

        Enemy_Test.myEvent += angryCharacter;
    }

    void Update()
    {
        if(isAlive) followPlayer(player.transform.position);
    }

    public void setCharacter()
    {
        navMeshAgent.speed =  character_speed;
        navMeshAgent.acceleration = character_acceleration;
        navMeshAgent.angularSpeed = character_angular_speed;
    } 

    public void followPlayer(Vector3 position)
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist >= character_range && dist <= 30)
        {
            navMeshAgent.SetDestination(position);
            anim.SetBool("isWalking", true);
        }
        else if(dist > 30)
        {
            // Patrullar
            // anim.SetBool("isWalking", false);
        }
        else
        {
            Vector3 noRotationLook = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(noRotationLook);
            navMeshAgent.SetDestination(transform.position);
            anim.SetBool("isWalking", false);
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                if(character_range <= 5)
                {
                    anim.SetTrigger("punch");
                }
                else
                {
                    anim.SetTrigger("shoot");
                }
                mainAttack();
                timer = character_cooldown;
            }
        }
    }

    public void mainAttack()
    {
        player.GetComponent<Player>().death(character_dammage);
    }

    public void death()
    {
        audioSource.PlayOneShot(clip);

        character_hp -= Player.player_dammage;
        anim.SetTrigger("hit");
        if(character_hp <= 0)
        {
            anim.SetTrigger("defeat");
            isAlive = false;
            rb.isKinematic = false;
            navMeshAgent.enabled = false;
            transform.Rotate(-10,0,0);
            Destroy(gameObject, 5);
            if(instantiaiteBlood)
            {
                Instantiate(blood,Player.gravePosition,Quaternion.LookRotation(new Vector3(-90,0,0)));
                instantiaiteBlood = false;
                dropObject();
            }
        }
        
    }

    public void dropObject()
    {
        float objectToDrop = Random.Range(1f, 100f);
        if(objectToDrop > 80 && boxAvailable)
        {
            Instantiate(box,transform.position,Quaternion.identity);
            boxAvailable = false;
        }
        else
        {
            Instantiate(coin,new Vector3(transform.position.x,transform.position.y + 1,transform.position.z),Quaternion.identity);
        }
    }

    public virtual void angryCharacter()
    {
        character_name = "Angry Dagger";
        character_hp = 150;
        character_speed = 8;
        character_range = 1.5f;
        character_dammage = 25;
        setCharacter();
    }

    void OnDisable()
    {
        Enemy_Test.myEvent -= angryCharacter;
    }
}
