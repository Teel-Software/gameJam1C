using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Vector2 movement;
    public Rigidbody2D rb;
    public Transform tank;
    public Animator animator;

    void Awake()
    {
        moveSpeed = PaEManager.GetPlayer().Speed;
        //animator.SetFloat("TurnSide", 0);
    }

    
    //float turnSide;

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.W))
		{
			tank.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
		}
		else if(Input.GetKey(KeyCode.S))
		{
			tank.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
		}
		else if(Input.GetKey(KeyCode.A))
		{
			tank.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
		}
		else if(Input.GetKey(KeyCode.D))
		{
			tank.localRotation = Quaternion.Euler(new Vector3(0, 0, -90));
		}
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
