using System.Collections;
using UnityEngine;

namespace Scavenging
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        public LayerMask solidObjectsLayer;

        private bool isMoving;

        private Vector2 input; // Creates input ref

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isMoving)
            {
                input.x = Input.GetAxisRaw("Horizontal"); // Left and right
                input.y = Input.GetAxisRaw("Vertical"); // Up and down

                if (input.x != 0) input.y = 0; // No diagonal movement

                if (input != Vector2.zero) // If player isn't moving, run this
                {
                    animator.SetFloat("moveX", input.x);
                    animator.SetFloat("moveY", input.y);
                
                    var targetPos = transform.position; // Gets current pos of player
                    targetPos.x += input.x; // Makes targetPos.x -1 (Left) or +1 (Right)
                    targetPos.y += input.y; // Makes targetPos.y -1 (Down) or +1 (Up)

                    if (isWalkable(targetPos)) // if the targetPos can be walked to.
                    {
                        StartCoroutine(Move(targetPos)); // Calls 'Move' enumerator
                    }

                }
            }
            animator.SetBool("isMoving", isMoving);
            
            // idk if this does anything. maybe dont touch it? idk, im not the boss of you.
            if (Input.GetKey(KeyCode.E))
            {
                
            }
        }

        IEnumerator Move(Vector3 targetPos) // Makes player move from current to target position.
        {
            isMoving = true; // Makes bool true, so the rest of the movement is unable to be used when still moving
            while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) // Checks that the target position and current position is greater than a small value
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime); // Moves the player towards the targetPos by a small amount
                yield return null; // Stops execution
            }

            transform.position = targetPos; // Makes players position the targetPosition
            isMoving = false; // Turns bool off to be used again
        }

        private bool isWalkable(Vector3 targetPos) // checks to see if the tile is walkable
        {
            if(Physics2D.OverlapCircle(targetPos, 0.05f, solidObjectsLayer) != null) // if the targetPosition is in a solidObjects layer, don't walk.
            {
                return false;
            }

            return true; // If not, then walk.
        }
    }
}
