using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CharacterMovement : MonoBehaviour
{   
    public Joystick joystick;
    private float joyHorizontal, JoyVertical = 0;
    [SerializeField] float move_speed;

    Animator anim; 
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
   
    void LateUpdate()
    {
        joyHorizontal = joystick.Horizontal;
        JoyVertical = -joystick.Vertical;

        if (joyHorizontal != 0f || JoyVertical != 0f)
        {

           // Vector3 direction = new Vector3(JoyVertical, 0, joyHorizontal).normalized;
           // transform.Translate(direction * move_speed, Space.World);
           Vector3 pos = transform.position;
           CharacterMovementandRotation(new Vector3(pos.x + JoyVertical, pos.y, pos.z + joyHorizontal));
           anim.SetBool("isWalk",true);
        }
        else{
            anim.SetBool("isWalk",false);
        }
        
    
    }

    public void CharacterMovementandRotation(Vector3 toLook)  
    {
        transform.LookAt(toLook);
        transform.Translate(Vector3.forward * move_speed * Time.deltaTime);
    }
  
}