using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class PowerUpBase : MonoBehaviour
{
    // ENCAPSULATION
    public int value { get; set; }
    // Time To Double in seconds
    public int ttd { get; set; }
    public float timePassed { get; set; }
    // This will be the player object
    public GameObject leader;
    // Text on this powerup
    public TextMeshPro textBox;

    void LateUpdate()
    {
        if (leader == null && timePassed > ttd) {
            timePassed = 0;
            TTDAction();

        } else {
            timePassed += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        PowerUpSpawner spawner = this.GetComponentInParent<PowerUpSpawner>();
        if (spawner != null && player != null) {
            spawner.ClaimPowerup();
            DoPowerUp(player);

        }
    }

    // Called when the PowerUp is claimed by the player
    public virtual void DoPowerUp(PlayerController player) { }

    // Called when the TTD of the powerup is reached.
    public virtual void TTDAction()  { }


}

