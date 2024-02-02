using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class MovementController : MonoBehaviour
{

    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject parachute;
    [SerializeField] Transform bombDropPoint;
    [SerializeField] bool allowDrop;
    [SerializeField] float dropRate;
    [SerializeField] public int bombCounter;

    // Start is called before the first frame update
    void Start()
    {
        allowDrop = true;
        dropRate = 2.0f;
        rb = GetComponent<Rigidbody2D>();
        bombCounter = 3; 
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 14);
        Gamepad myGamepad = Gamepad.current;

        if (myGamepad != null)
        {
            if (myGamepad.dpad.left.isPressed || myGamepad.leftStick.x.value < 0)
            {
                rb.AddForce(new Vector2(-6.0f, 0), ForceMode2D.Force);
                anim.SetBool("isRotateLeft", true);
                anim.SetBool("isRotateLeftOpen", true);
            }
            if (myGamepad.dpad.left.wasReleasedThisFrame || myGamepad.leftStick.x.value == 0)
            {
                anim.SetBool("isRotateLeft", false);
                anim.SetBool("isRotateLeftOpen", false);
            }
            if (myGamepad.dpad.right.isPressed || myGamepad.leftStick.x.value > 0)
            {
                rb.AddForce(new Vector2(6.0f, 0), ForceMode2D.Force);
                anim.SetBool("isRotateRight", true);
                anim.SetBool("isRotateRightOpen", true);
            }
            if (myGamepad.dpad.right.wasReleasedThisFrame || myGamepad.leftStick.x.value == 0)
            {
                anim.SetBool("isRotateRight", false);
                anim.SetBool("isRotateRightOpen", false);
            }

            if (myGamepad.leftTrigger.isPressed)
            {
                anim.SetBool("isDropping", false);
                anim.SetBool("isRotateRight", false);
                anim.SetBool("isRotateLeft", false);
                rb.velocity = new Vector2(rb.velocity.x, -6.6f);
            }
            else
            {
                anim.SetBool("isDropping", true);
                anim.SetBool("isRotateLeftOpen", false);
                anim.SetBool("isRotateRightOpen", false);
                rb.velocity = new Vector2(rb.velocity.x, -2.3f);

            }
            if (myGamepad.leftTrigger.wasReleasedThisFrame)
            {
                if (rb.velocity.y <= -5)
                    rb.velocity += new Vector2(rb.velocity.x, 4.0f);
            }
            if (myGamepad.leftShoulder.wasPressedThisFrame && allowDrop && bombCounter > 0)
            {
                StartCoroutine(DropRate());
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(new Vector2(-6.0f, 0), ForceMode2D.Force);
                anim.SetBool("isRotateLeft", true);
                anim.SetBool("isRotateLeftOpen", true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetBool("isRotateLeft", false);
                anim.SetBool("isRotateLeftOpen", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(new Vector2(6.0f, 0), ForceMode2D.Force);
                anim.SetBool("isRotateRight", true);
                anim.SetBool("isRotateRightOpen", true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool("isRotateRight", false);
                anim.SetBool("isRotateRightOpen", false);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("isDropping", false);
                anim.SetBool("isRotateRight", false);
                anim.SetBool("isRotateLeft", false);
                rb.velocity = new Vector2(rb.velocity.x, -6.6f);
            }
            else
            {
                anim.SetBool("isDropping", true);
                anim.SetBool("isRotateLeftOpen", false);
                anim.SetBool("isRotateRightOpen", false);
                rb.velocity = new Vector2(rb.velocity.x, -2.3f);

            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (rb.velocity.y <= -5)
                    rb.velocity += new Vector2(rb.velocity.x, 4.0f);
            }
            if (Input.GetMouseButtonDown(1) && allowDrop && bombCounter > 0)
            {
                StartCoroutine(DropRate());
            }
        }


    }
    IEnumerator DropRate()
    {
        allowDrop = false;
        Instantiate(parachute, bombDropPoint.position, Quaternion.identity);
        bombCounter--; 
        yield return new WaitForSeconds(dropRate);
        allowDrop = true;
    }

}
