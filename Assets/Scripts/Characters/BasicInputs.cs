using UnityEngine;
using UnityEngine.InputSystem;

public class BasicInputs : MonoBehaviour
{

    public Animator animator;

    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    public Vector2 input;
    private PlayerInput playerInput;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            input = playerInput.actions["Move"].ReadValue<Vector2>();
            //bloquea el movimiento diagonal
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }

            speedX = input.x * movSpeed;
            speedY = input.y * movSpeed;

            //Activa las animaciones
            animator.SetFloat("Horizontal", speedX);
            animator.SetFloat("Vertical", speedY);
            animator.SetFloat("Speed", new Vector2(speedX, speedY).sqrMagnitude);

            //Activa los idles de las animaciones
            if (input != Vector2.zero)
            {
                animator.SetFloat("LastHorizontal", speedX);
                animator.SetFloat("LastVertical", speedY);
            }
            //Abre el menu de objetos
            if (playerInput.actions["Open UI Menu"].IsPressed())
                GetComponentInChildren<PlayerWeaponUIController>(true).MenuPressed();
            else
                GetComponentInChildren<PlayerWeaponUIController>(true).MenuReleased();
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
            rb.MovePosition(rb.position + new Vector2(input.x, input.y).normalized * movSpeed * Time.fixedDeltaTime);
    }

    public void DisableMovement()
    {
        Debug.Log("desactiva el movimiento");
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }



}
