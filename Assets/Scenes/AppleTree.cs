using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    //prefab for instantiating apples
    public GameObject applePrefab;

    //speed at which appletree moves
    public float speed = 1f;

    //distance where appletree turns around
    public float leftAndRightEdge = 10f;

    //chance that the appletree will change direction
    public float chanceToChangeDirections = 0.1f;

    //Rate at which apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    private void Start()
    {
        //dropping apples every second
        Invoke("DropApple", 2f);

    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);

        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
    private void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //change direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }

    }
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
