using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private Transform weaponCollider;
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    private PlayerActions playerActions;
    private Animator myAnimator;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;
    private static readonly int TriggerAttack = Animator.StringToHash("Attack");
    private Camera mainCamera;
    private GameObject slashAnim;
    
    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        myAnimator = GetComponent<Animator>();
        playerActions = new PlayerActions();
        mainCamera = Camera.main;
    }
    
    private void OnEnable()
    {
        playerActions.Enable();
    }
    
    // dont want to passing through anything, so use "_"
    private void Start()
    {
        playerActions.Combat.Attack.started += _ => Attack();
    }
    
    private void Attack()
    {
        myAnimator.SetTrigger(TriggerAttack);
        
        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
    }

    private void SwingUpFlipAnim()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);
        if (playerController.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void SwingDownFlipAnim()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (playerController.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    private void Update() 
    {
        MouseFollowWithOffset();
    }
    
    private void MouseFollowWithOffset()
    {
        if (Object.Equals(mainCamera, null)) return;
        
        var mousePos = Input.mousePosition;
        var playerScreenPoint = mainCamera.WorldToScreenPoint(playerController.transform.position);
        var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, 0);
            weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
            weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
         
    }
}
