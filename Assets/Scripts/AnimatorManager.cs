using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    float velocity = 0.0f;
    public float acceleration = 0.1f;

    //Animacions
    Animator animator;
    int VelocityHash;

    public KeyCode sprintKey = KeyCode.LeftShift;
    bool running = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");

    }

    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(Input.GetKey(sprintKey) && (horizontalInput != 0 || verticalInput != 0)){
            running = true;
        }
        else running = false;

        velocity = CalcularVelocitat();
        
        animator.SetFloat(VelocityHash, velocity);
    }

    float CalcularVelocitat(){
        float velocitat = 0f;
        if(running) velocitat = 1;
        else if(horizontalInput != 0 || verticalInput != 0){
            velocitat = 0.5f;
        }

        return velocitat;
    }
}
