using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
public float speed;
public float jumpForce;
private float moveInput;
private bool facingRight = true;
private bool isGrounded;
public Transform groundCheck;
public float checkRadius;
public LayerMask whatIsGround;
private int extraJump;
public int extraJumpValue;
private Animator anim;
private Rigidbody2D rb;
// Start is called before the first frame update
void Start()
{
anim = GetComponent<Animator>();
extraJump = extraJumpValue;
rb = GetComponent<Rigidbody2D>();
}

// Update is called once per frame
void FixedUpdate()
{
isGrounded =

Physics2D.OverlapCircle(groundCheck.position, checkRadius,
whatIsGround);

moveInput =

Input.GetAxis("Horizontal");
rb.velocity = new Vector2(moveInput * speed,

rb.velocity.y);

if(moveInput == 0){
anim.SetBool("isRunning", false);
}else{
anim.SetBool("isRunning", true);
}
if(facingRight == false && moveInput > 0){
Flip();
}else if(facingRight == true && moveInput < 0){
Flip();
}
}
void Update()
{
if(isGrounded == true){
extraJump = extraJumpValue;
}
if(Input.GetButtonDown("Jump") &&

extraJump > 0){

rb.velocity = Vector2.up * jumpForce;
//AudioManager.instance.Play("Jump");
extraJump--;
}else

if(Input.GetButtonDown("Jump") && extraJump
== 0 && isGrounded == true){

rb.velocity = Vector2.up * jumpForce;
}
}
void Flip()
{
facingRight = !facingRight;
Vector3 Scaler = transform.localScale;
Scaler.x *= -1;
transform.localScale = Scaler;
}
}