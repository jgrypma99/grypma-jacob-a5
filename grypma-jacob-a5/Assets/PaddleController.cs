using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    //declarations
    public float movementSpeed = 10;
    Vector2 movePaddle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //move paddle left/right pased on horizontal input
        movePaddle = new Vector2(UnityEngine.Input.GetAxis("Horizontal"), 0);
        transform.Translate(movePaddle * movementSpeed * Time.deltaTime);
    }
}
