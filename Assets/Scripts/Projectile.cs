using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 2;
    private Animator destroyFighter;
    private Animator destroyScout;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fighter") || collision.gameObject.CompareTag("Scout"))
        {
            Animator enemyAnimator = collision.gameObject.GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                if (collision.gameObject.CompareTag("Fighter"))
                {
                    enemyAnimator.Play("DestroyFighter");
                }
                else if (collision.gameObject.CompareTag("Scout"))
                {
                    enemyAnimator.Play("DestroyScout");
                }

                Destroy(collision.gameObject, enemyAnimator.GetCurrentAnimatorStateInfo(0).length + 0.75f);
            }
            else
            {
                Destroy(collision.gameObject); // If no animator, destroy immediately
            }

            Destroy(gameObject); // Destroy the current gameObject (the one this script is attached to)
        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyAfterDelay(GameObject objectToDestroy, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Destroy the object after the delay
        Destroy(objectToDestroy);
    }

}
