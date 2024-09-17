using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 3; // Damage to apply when the player attacks

    private bool canAttack = false; // Flag to determine if attack can be made

    private void Update()
    {
        // Check if the player presses the attack button (e.g., Left Shift)
        if (Input.GetKeyDown(KeyCode.LeftShift) && canAttack)
        {
            // Apply damage to all players within the attack area
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().size, 0f);
            foreach (var hitCollider in hitColliders)
            {
                Player player = hitCollider.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // When an enemy enters the collider, set canAttack to true
        if (collider.GetComponent<Player>() != null)
        {
            canAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // When an enemy exits the collider, set canAttack to false
        if (collider.GetComponent<Player>() != null)
        {
            canAttack = false;
        }
    }

    private void OnDrawGizmos()
    {
        // Draw a box gizmo for the attack area for easier visualization in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }
}
