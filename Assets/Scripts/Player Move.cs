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

    public bool hasChip = false;
    public bool hasTomato = false;
    public bool hasOnion = false;
    public bool hasMeat = false;
    public bool hasCheese = false;
    public bool hasLettuce = false;
    private bool hasAll = false;

    private bool mobileControlsInUse = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plrRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            mobileControlsInUse = false;
        }
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
        if (mobileControlsInUse == false) {
            horiz = Input.GetAxis("Horizontal");
            verti = Input.GetAxis("Vertical");
        }
        Vector3 move = new Vector3(horiz * speed, verti * jumpHeight);
        transform.position += move * Time.deltaTime;
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
    public void SetPlayerMoveMobile(float x, float y)
    {
        mobileControlsInUse = true;
        horiz = x;
        verti = y;
    }
    public void ResetPlayerMoveMobile()
    {
        horiz = 0;
        verti = 0;
    }
}