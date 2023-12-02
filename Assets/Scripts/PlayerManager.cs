using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public class RPSCharacter : MonoBehaviour
    {
        public enum RPS
        {
            //Different character types.
            Rock,
            Paper,
            Scissors
        }

        public RPS characterType;
        public float speed;
        public int damage;
        public int health;

        private Rigidbody2D rb2d;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            //movement and speed functionalities.
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            rb2d.velocity = movement * speed;

            //The player must click on 1, 2, or 3 to switch between characters.
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                characterType = RPS.Rock;
                damage = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                characterType = RPS.Paper;
                damage = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                characterType = RPS.Scissors;
                damage = 1;
            }
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            //NOTE: use TAGS for enemies!
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
}

