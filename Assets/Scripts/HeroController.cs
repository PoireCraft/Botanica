using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    private Rigidbody2D rigidbody ;
    private Animator anim;

    public float speed = 10f ;
	bool facingRight=true;
    bool facingUp = true;
	
	
	
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        //Move 8 Directions
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        Vector2 mouvement = new Vector2(horizontal * speed, vertical * speed);

        //Facing Direction
        if (horizontal < 0 && facingRight)
        {
            flipH();
        }
        else if (horizontal > 0 && !facingRight)
        {
            flipH();
        } else if ( horizontal==0)
        {
            if(vertical<0 && facingUp)
            {
                facingUp = !facingUp;
            } else if (vertical>0 && !facingUp)
            {
                facingUp = !facingUp;
            }
        }

        anim.SetFloat("VerticalSpeed", vertical);


        //Speed==0
        if (Mathf.Abs(vertical) > 0 || Mathf.Abs(horizontal) > 0)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
            facingUp = true;
        }
            

        mouvement *= Time.deltaTime;
        transform.Translate(mouvement);
    }
    
	
    //Flip Horizontal to face the correct direction
	void flipH() {
		facingRight=!facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x*=-1;
		transform.localScale=theScale;
	}
}
