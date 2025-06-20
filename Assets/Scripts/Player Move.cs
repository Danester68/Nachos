using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D plrRigidbody;

    public GameObject finishMenu;
    //public GameObject ovenWarning;

    private float horiz;
    private float verti;

    private bool canJump;

    public int speed;

    public int jumpHeight;

    private bool hasChip = false;
    private bool hasTomato = false;
    private bool hasOnion = false;
    private bool hasMeat = false;
    private bool hasCheese = false;
    private bool hasLettuce = false;
    private bool hasAll = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plrRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (hasChip && hasTomato && hasOnion && hasMeat && hasCheese && hasLettuce) {
            hasAll = true;
        }
    }
    void FixedUpdate()
    {
        // Old jump check
        //if (plrRigidbody.velocity.y == 0) {
        //    jump();
        //}
        jump();
        horiz = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(horiz * speed, verti * jumpHeight);
        transform.position += move * Time.deltaTime;
    }

    void jump() {
        verti = Input.GetAxis("Vertical");
    }
    
    void OnTriggerEnter2D(Collider2D collider) {
        switch(collider.gameObject.tag) {
            case "Chip":
                hasChip = true;
                Destroy(collider.gameObject);
                break;
            case "Tomato":
                hasTomato = true;
                Destroy(collider.gameObject);
                break;
            case "Onion":
                hasOnion = true;
                Destroy(collider.gameObject);
                break;
            case "Meat":
                hasMeat = true;
                Destroy(collider.gameObject);
                break;
            case "Cheese":
                hasCheese = true;
                Destroy(collider.gameObject);
                break;
            case "Lettuce":
                hasLettuce = true;
                Destroy(collider.gameObject);
                break;
            case "Oven":
                if (hasAll) {
                    //ovenWarning.SetActive(false);
                    finishMenu.SetActive(true);
                } else {
                    //ovenWarning.SetActive(true);
                }
                break;
        }
    }
}