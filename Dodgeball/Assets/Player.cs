using UnityEngine;

/// <summary>
/// Control the player on screen
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    /// <summary>
    /// Prefab for the orbs we will shoot
    /// </summary>
    public GameObject OrbPrefab;

    /// <summary>
    /// How fast our engines can accelerate us
    /// </summary>
    public float EnginePower = 1;
    
    /// <summary>
    /// How fast we turn in place
    /// </summary>
    public float RotateSpeed = 1;

    /// <summary>
    /// How fast we should shoot our orbs
    /// </summary>
    public float OrbVelocity = 10;

    // initial force to the rigidbody
    public Vector2 INITIAL_FORCE = new Vector2(1.0f, 1.0f);

    public Rigidbody2D rigidbody_me;

    //public Rigidbody2D rigidbody_bullet;


    void Start()
    {
        rigidbody_me = GetComponent<Rigidbody2D>();
     
    }

    /// <summary>
    /// Fire if the player is pushing the button for the Fire axis
    /// Unlike the Enemies, the player has no cooldown, so they shoot a whole blob of orbs
    /// The orb should be placed one unit "in front" of the player.  transform.right will give us a vector
    /// in the direction the player is facing.
    /// It should move in the same direction (transform.right), but at speed OrbVelocity.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Update()
    {
        // TODO
        if(Input.GetButton("Fire")) {
            GameObject bullet = Instantiate(OrbPrefab, this.transform.position+this.transform.right, this.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = this.transform.right * OrbVelocity;
        }


    }

    /// <summary>
    /// Accelerate and rotate as directed by the player
    /// Apply a force in the direction (Horizontal, Vertical) with magnitude EnginePower
    /// Note that this is in *world* coordinates, so the direction of our thrust doesn't change as we rotate
    /// Set our angularVelocity to the Rotate axis time RotateSpeed
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void FixedUpdate()
    {
        // TODO
        
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector2 applied_force = new Vector2(h, v);
        rigidbody_me.AddForce(EnginePower * applied_force);

        rigidbody_me.angularVelocity = RotateSpeed * Input.GetAxis("Rotate");

    }

    /// <summary>
    /// If this is called, we got knocked off screen.  Deduct a point!
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void OnBecameInvisible()
    {
        ScoreKeeper.ScorePoints(-1);
    }
}
