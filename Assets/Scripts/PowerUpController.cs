using Unity.VisualScripting;
using UnityEngine;

// INHERITANCE
public class PowerUpController : PowerUpBase
{

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
        leader = player.gameObject;
        // this.transform.SetParent(player.transform);
        Collider col = this.GetComponent<Collider>();
        col.isTrigger = false;
        player.AddTail(this.gameObject);
    }

    // POLYMORPHISM
    // Will double the value of this powerup
    public override void TTDAction()
    {            
        value *= 2;
        textBox.text = value.ToString();
    }
}

