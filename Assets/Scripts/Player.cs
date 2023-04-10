using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;

    void Awake()
    {
        moveSpeed = PaEManager.GetPlayer().Speed;
        //animator.SetFloat("TurnSide", 0);
    }

    Vector2 movement;
    //float turnSide;

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        //GetSideToTurn();

        // if (!Input.anyKeyDown){
        //     animator.SetFloat("TurnSide", turnSide);
        // }
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + (moveSpeed * Time.fixedDeltaTime * movement));
    }

    // private void GetSideToTurn(){
    //     if (animator.GetFloat("Horizonal") == -1) {
    //         turnSide = 1.0f;
    //     }
    //     else if (animator.GetFloat("Horizonal") == 1) {
    //         turnSide = 2.0f;
    //     }

    //     else if (animator.GetFloat("Vertical") == -1) {
    //         turnSide = 3.0f;
    //     }
    //     else {// if (animator.GetFloat("Vertical") == 1){
    //         turnSide = 0.0f;
    //     }

    //     //return 0.0f;
    // }
}
