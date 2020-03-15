using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float MoveSpeed = 1f;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidbody2d;
    
    public MovingObject()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    protected void Move(int xDir, int yDir)
    {
        Vector2 current = transform.position;
        Vector2 destination = current + new Vector2(xDir, yDir);
        StartCoroutine(MoveToDestinationAtMoveSpeed(destination));
    }

    protected IEnumerator MoveToDestinationAtMoveSpeed(Vector3 destination)
    {
        float remainingDistance = (transform.position - destination).magnitude;

        while(remainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rigidbody2d.position, destination, Time.deltaTime * MoveSpeed);
            rigidbody2d.MovePosition(newPosition);
            remainingDistance = (transform.position - destination).magnitude;
            yield return null;
        }
    }
}
