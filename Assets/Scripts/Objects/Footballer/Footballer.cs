using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Footballer : Player, Fallable
{
    [HideInInspector]
    public float verticalInput;
    [HideInInspector]
    public float horizontalInput;
    [HideInInspector]
    public float shotInput;
    [HideInInspector]
    public float passInput;
    [HideInInspector]
    public float slideInput;

    private bool falling, fallCommand;
    public bool IsFalling { get => falling; set => falling = value; }
    public Player TeamMate { get => teamMate; set => teamMate = value; }
    public bool FallCommand { get => fallCommand; set => fallCommand = value; }
    public Dropper Dropper { get => dropper; set => dropper = value; }

    [SerializeField]
    private Player teamMate;

    private Dropper dropper;


    public void Start()
    {
        base.Start();
        dropper = GetComponentInChildren<Dropper>();
    }

    public void Update()
    {
        base.Update();

    }

    

    public void FixedUpdate()
    {
        base.FixedUpdate();



    }


    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 dir = transform.position - collision.transform.position;
            dir.Normalize();
            Rigidbody.AddForce(dir * 10000f);

        }


    }

}
