using UnityEngine;

[CreateAssetMenu]
public class Projectile : ScriptableObject
{
    public float dmg; //Not sure about making this public
    public float speed; //Neither this, I'm just testing shit really
    public Vector3 spawnLocation; //Rider sometimes just won't work

    //Figure out what we should do with the beam/missile types
    //TODO - Also, future Alyx will have to care about State Machines in the projectiles or enemies attacked by them
}
