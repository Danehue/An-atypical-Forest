using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour
{
    CharacterController controller;
    public static float player_hp, player_dammage, player_score, player_boxes;
    Vector3 dir;
    float getInterval, timer;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject bloodFX;
    public static Vector3 gravePosition, graveRotation;

    public AudioSource audioSource;
    public AudioSource audioSourceLightPlane;
    public AudioClip player_hit; 
    public AudioClip player_repair;

    public Animator anim;
    private static bool grabAnim = false;

    public Slider sliderLightPlane;
    private float repairTime;
    private bool repairing, onePerTime;

    public static event Action lightPlaneEvent;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        player_hp = 500;
        onePerTime = true;
    }

    void Update()
    {
        handdleMove();
        attack();
        if(grabAnim)
        {
            anim.SetTrigger("grab");
            grabAnim = false;
        }

        if(sliderLightPlane.value >= 5)
        {
            lightPlaneEvent?.Invoke();
        }
    }

    void handdleMove()
    {
        // Movement
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        dir = (mainCamera.transform.forward * ver + mainCamera.transform.right * hor).normalized;
        controller.SimpleMove(dir * 10);
        if(dir != Vector3.zero)
        {
            anim.SetBool("isWalking", true);
        }
        if(dir == Vector3.zero)
        {
            anim.SetBool("isWalking", false);
        }


        //Rotation 
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMask))
        {
            Vector3 mouseRealTime = new Vector3(hit.point.x,transform.position.y,hit.point.z - transform.position.y);
            transform.LookAt(mouseRealTime);
        }
    }

    void attack()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * Weapon.weapon_range;
        Debug.DrawRay(Weapon_Test.currentWeapon.transform.position, forward, Color.green);

        getInterval = Weapon.weapon_interval;
        timer += Time.deltaTime;
        if(timer >= getInterval && !repairing)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(Weapon.weapon_name == "Knife")
                {
                    anim.SetTrigger("punch");
                }
                else
                {
                    anim.SetTrigger("shoot");
                }
                Weapon.staticAudioSource.PlayOneShot(Weapon.staticClip);
                Ray ray = new Ray(Weapon_Test.currentWeapon.transform.position, transform.forward);
                RaycastHit hit;
        
                if(Physics.Raycast(ray, out hit, Weapon.weapon_range))
                {
                    
                    if(hit.transform.gameObject.CompareTag("Enemy"))
                    {
                        player_dammage = Weapon.weapon_dammage;

                        Instantiate(bloodFX,hit.point,Quaternion.LookRotation(hit.normal));

                        Ray rayY = new Ray(hit.point, transform.up * -1f);
                        RaycastHit hitY;
                        if(Physics.Raycast(rayY, out hitY, 10f))
                        {
                            gravePosition = new Vector3(hitY.point.x,hitY.point.y + .1f,hitY.point.z);
                        }

                        hit.transform.gameObject.GetComponent<Enemy>().death();
                        anim.SetBool("isShooting", false);
                    }
                }
                timer = 0f; 
            }
        }
    }

    public static void grabObject(GameObject box)
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            box.SetActive(false);
            player_boxes ++;
            Enemy.boxAvailable = true;
            grabAnim = true;
        }
    }

    public void death(float character_dammage)
    {
        audioSource.PlayOneShot(player_hit);
        player_hp -= character_dammage;
        anim.SetTrigger("hit");
        audioSourceLightPlane.Stop();
        repairTime = 0;
        anim.SetBool("repair", false);
        if(player_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            player_score ++;
        }
        
    }   

    void OnTriggerStay(Collider other)
    {
        if(other.transform.CompareTag("LightPlane"))
        {
            if(player_boxes > 0 && Input.GetKey(KeyCode.Q) && dir == Vector3.zero && onePerTime)
            {
                repairing = true;
                if(!audioSourceLightPlane.isPlaying)
                {
                    audioSourceLightPlane.PlayOneShot(player_repair);
                }
                anim.SetBool("repair", true);
                repairTime += Time.deltaTime;
                if(repairTime >= 10 )
                {
                    sliderLightPlane.value++;
                    player_boxes--;
                    onePerTime = false;
                }
            }
            else
            {
                onePerTime = true;  
                repairing = false;
                audioSourceLightPlane.Stop();
                repairTime = 0;
                anim.SetBool("repair", false);  
            }
            
        }
    }
}
