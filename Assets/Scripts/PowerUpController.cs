using Unity.VisualScripting;
using UnityEngine;

// INHERITANCE
public class PowerUpController : PowerUpBase
{

    private bool collected = false;
    void Start()
    {
        value = 2;
        ttd = 6;
        timePassed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (leader != null) {
            // transform.position = Vector3.MoveTowards(transform.position, leader.transform.position, .03f);
        }
    }

    // POLYMORPHISM
    public override void DoPowerUp(PlayerController player)
    {
        if (!collected) {
            leader = player.gameObject;
            // this.transform.SetParent(player.transform);
            // Collider col = this.GetComponent<Collider>();
            // col.isTrigger = false;
            player.AddTail(this.gameObject);
            collected = true;
        }

    }

    // POLYMORPHISM
    // Will double the value of this powerup
    public override void TTDAction()
    {            
        updateValue(value * 2);
    }
    
    public void updateValue(int newValue)
    {
        value = newValue;
        textBox.text = value.ToString();
    }

    public void followLeader(Vector3 lastPosition, Quaternion lastRotation)
    {
        Transform thisTransform = gameObject.transform;
        lastPosition -= new Vector3(1.1f, 0, 1.1f);
        // dont know how to make these rotate properly for now.
        thisTransform.position = Vector3.MoveTowards(thisTransform.position, lastPosition, 10f);
        // thisTransform.Translate(lastPosition);
    }

    public Vector3 getLocation()
    {
        return gameObject.transform.position;
    }

    public Quaternion getRotation()
    {
        return gameObject.transform.rotation;
    }
}

