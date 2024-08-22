using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime = 0.8f;
    public  float nextFireTime = 0f;
    public static int noOfClicks = 0;
    public float lastClickedTime = 0;
    public float maxComboDelay = 1;

    private AudioSource au; 
    public List<AudioClip> clipList;

    private void Start()
    {
        anim = GetComponent<Animator>();

        au = GetComponent<AudioSource>();
    }
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit01"))
        {
            anim.SetBool("hit01", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit02"))
        {
            anim.SetBool("hit02", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit03"))
        {
            anim.SetBool("hit03", false);
            noOfClicks = 0;
        }


        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        //cooldown time
        if (Time.time > nextFireTime)
        {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            au.PlayOneShot(clipList[3]);

        }
    }

    void OnClick()
    {
        //so it looks at how many clicks have been made and if one animation has finished playing starts another one.
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
        {
            anim.SetBool("hit01", true);
            au.PlayOneShot(clipList[0]);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit01"))
        {
            anim.SetBool("hit01", false);
            anim.SetBool("hit02", true);
            au.PlayOneShot(clipList[1]);
        }
        if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && (anim.GetCurrentAnimatorStateInfo(0).IsName("Hit02") || anim.GetCurrentAnimatorStateInfo(0).IsName("New State")))
        {
            anim.SetBool("hit02", false);
            anim.SetBool("hit03", true);
            au.PlayOneShot(clipList[2]);
            noOfClicks = 0; 
        }
    }
}