using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrusterController : MonoBehaviour
{
    public ConstantForce2D constantForce2D;
    public Rigidbody2D rigidbody2D;
    public ParticleSystem particleSystem;
    public bool invertThrust = false;
    public bool enabled = true;
    // Start is called before the first frame update
    void Start()
    {
        //if (null != this.rigidbody2D)
        //{
        //    this.rigidbody2D.SetRotation(this.transform.rotation.eulerAngles.y);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ApplyForce(float thrustValue )
    {
        if (!enabled)
        {
            return;
        }
        if (thrustValue>1)
        {
            thrustValue = 1;
        }
        var force = new Vector2(
            0.0f, 0.0f);
        force.y = thrustValue;
        this.constantForce2D.relativeForce = force;

        // set particles
        if (force.x < 0.10f)
        {
            //this.particleSystem.Stop();
        }
        if (thrustValue> 0.010f)
        {
            //this.particleSystem.Play();
            ParticleSystem.MainModule particleMain = this.particleSystem.main;
            particleMain.startSpeed = thrustValue;
            particleMain.startLifetime = 0.1f;
        }

    }
}
