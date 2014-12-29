using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    private Vector2 _movement;
    private float horizontal;
    private Rigidbody2D _rigid;

    public float RunSpeed = 5;
    public ProxyTrigger OnGround;

    // Use this for initialization
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        _movement = new Vector2(horizontal * RunSpeed, 0);

        if (!OnGround.IsContract)
            _movement.y += Physics2D.gravity.y * _rigid.gravityScale;


        _rigid.velocity = _movement;

    }
}
