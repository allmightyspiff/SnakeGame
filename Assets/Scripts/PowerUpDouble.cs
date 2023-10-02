using UnityEngine;

// INHERITANCE
public class PowerUpDouble : PowerUpBase
{

    void Start()
    {
        value = 0;
        ttd = 60;
        timePassed = 0.0f;
    }

    // POLYMORPHISM
    public override void DoPowerUp(PlayerController player)
    {
            // Double the players points
            int currentPoint = player.GetPoints();
            player.UpdatePoints(currentPoint);
            // Increase the size of the player when they get this powerup.
            Vector3 ScaleChange = new Vector3(0.5f, 0.5f, 0.5f);
            player.transform.localScale += ScaleChange;
            Destroy(this.gameObject);
    }

    // POLYMORPHISM
    // Will delete this powerup after the TTD time
    public override void TTDAction()
    {            
        Destroy(this.gameObject);
    }

}

