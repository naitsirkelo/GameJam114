using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float jumpForce = 8;
    public float speed = 8;
    public float acc = 20;

    private float currentSpeed;
    private float horizontal;

    private int goldCount = 0;
    private int totalGold = 0;
    private int taxBracket = 1;

    bool gameOver = false;

    public bool onGround;
    private bool facingRight = true;

    private Vector2 move;

    private PlayerPhysics playerPhysics;
    public Rigidbody2D rb;
    public Animator animator;

    [SerializeField] private Transform popup;
    [SerializeField] private Transform popupBill;

    static AudioSource audioSource;

    public Text goldText;

    void Start() {

        Time.timeScale = 1f;

        audioSource = gameObject.GetComponent<AudioSource>();
        playerPhysics = GetComponent<PlayerPhysics>();
        rb = GetComponent<Rigidbody2D>();

        UpdateGoldCounter(goldCount);

    }

    void Update() {

        rb.freezeRotation = true;

        if (goldCount > 20) { taxBracket = 5; }
        else if (goldCount > 15) { taxBracket = 4; }
        else if (goldCount > 10) { taxBracket = 3; }
        else if (goldCount > 5) { taxBracket = 2; }
        else { taxBracket = 1; }

        if (goldCount < 0) {

            gameOver = true;
            FindObjectOfType<GameOverController>().GameOver(totalGold);

        }

        horizontal = Input.GetAxisRaw("Horizontal") * speed;
        currentSpeed = Towards(currentSpeed, horizontal, acc);

        Vector3 scale = transform.localScale;
        if (horizontal > 0 && !facingRight) {

            facingRight = true;
            scale.x *= -1;

      } else if (horizontal < 0 && facingRight) {

          facingRight = false;
          scale.x *= -1;

      }

      transform.localScale = scale;

      if (Input.GetButtonDown("Jump") && onGround && !gameOver) {

          audioSource.Play();
          animator.SetBool("Jumping", true);
          rb.velocity = new Vector2(0, jumpForce);

      }

      move.x = currentSpeed;

      transform.Translate(move * Time.deltaTime);

    }

    private float Towards(float n, float target, float a) {

        if (n == target) {
            return n;
        }
        else {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target-n))? n : target;
        }

    }

    void OnCollisionEnter2D(Collision2D c) {

        if (c.gameObject.CompareTag("Ground")) {

            Debug.Log("Hit ground");
            animator.SetBool("Jumping", false);
            onGround = true;

        }

        if (c.gameObject.CompareTag("Gold")) {

            goldCount += 1;
            totalGold += 1;

            UpdateGoldCounter(goldCount);
            ShowPopup("Gold");

        }

        if (c.gameObject.CompareTag("Bill")) {

            if (goldCount > 20) {

                goldCount -= 5;

            } else if (goldCount > 15) {

                goldCount -= 4;

            } else if (goldCount > 10) {

                goldCount -= 3;

            } else if (goldCount > 5) {

                goldCount -= 2;

            } else {

                goldCount -= 1;

            }

            UpdateGoldCounter(goldCount);
            ShowPopup("Bill");

        }

    }

    void OnCollisionExit2D(Collision2D c) {

        Debug.Log("Jump");
        if (c.gameObject.CompareTag("Ground")) {

            onGround = false;

        }
    }

    void ShowPopup(string s) {

        switch (s) {

            case "Gold":
                Instantiate(popup);
                break;

            case "Bill":
                var go = Instantiate(popupBill);
                go.GetComponent<TextMesh>().text = "-"+taxBracket;
                break;

            default:
                break;

        }
    }

    void UpdateGoldCounter(int gold) {

        goldText.text = "Gold: " + gold;

    }

}
