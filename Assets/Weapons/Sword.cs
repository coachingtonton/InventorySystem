using System.Collections;
using UnityEngine;

public class Sword : Weapon
{

    // REFRENCES
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
    }

    public override void Attack()
    {
        Debug.Log("POLAYER USED THE FUCKING  SWORD");
        StartCoroutine(AttackRoutine());
    }

    public IEnumerator AttackRoutine()
    {
        /// THIS TURNS ON THE BOX COLLIDER, WAITS A BIT THEN TURNS BACK OFF
        /// ONTRIGGER INSIDE WEAPON HANDLES THE ONTRIGGER
        boxCollider2D.enabled = true;
        yield return new WaitForSeconds(.2f);
        boxCollider2D.enabled = false;
    }
}
