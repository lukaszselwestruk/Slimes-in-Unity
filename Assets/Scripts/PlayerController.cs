using UnityEngine;
public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;

        public bool FacingLeft { get => facingLeft; set => facingLeft = value; }
        
        private PlayerActions playerActions;
        private Vector2 movement;
        private Rigidbody2D rb;
        private Animator myAnimator;
        private SpriteRenderer mySpriteRenderer;
        private Camera mainCamera;
        private static readonly int MoveX = Animator.StringToHash("moveX");
        private static readonly int MoveY = Animator.StringToHash("moveY");
        private bool facingLeft;
        private void Awake()
        {
            playerActions = new PlayerActions();
            rb = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
            mySpriteRenderer = GetComponent<SpriteRenderer>();
            mainCamera = Camera.main;
        }
        // new input system requires this method.
        private void OnEnable()
        {
            playerActions.Enable();
        }

        private void PlayerInput()
        {
            movement = playerActions.Movement.Move.ReadValue<Vector2>();
            myAnimator.SetFloat(MoveX, movement.x);
            myAnimator.SetFloat(MoveY, movement.y);
        }

        private void Move()
        {
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        }
        private void Update()
        {
            PlayerInput();
        }

        private void FixedUpdate() 
        {
            SetPlayerFacingDirection();
            Move();
        }

        private void SetPlayerFacingDirection()
        {
            if (Object.Equals(mainCamera, null)) return;
            
            var playerScreenPoint = mainCamera.WorldToScreenPoint(transform.position);
            var mousePos = Input.mousePosition;
            if (mousePos.x < playerScreenPoint.x)
            {
                mySpriteRenderer.flipX = true;
                FacingLeft = true;
            }
            else
            {
                mySpriteRenderer.flipX = false;
                FacingLeft = false;
            }
           

        }
    }


