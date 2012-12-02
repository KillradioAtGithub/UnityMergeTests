using UnityEngine;

public class MovementSystem : MonoBehaviour {

	public Vector2 Speed;
	
	private Vector3 velocity;
	
	public void Start() 
    {
		// la variable velocity n'est cr��e qu'une fois.
		velocity = new Vector3(Speed.x, Speed.y, 0);
	}
	
	public void Update() 
    {
		// Mise � jour de la velocit� lorsqu'on modifie in-game.
		velocity.x = Speed.x;
		velocity.y = Speed.y;
	
		transform.Translate(velocity * Time.deltaTime);
	}

    public void SwitchVelocityX()
    {
        Speed.x = -Speed.x;
    }

    public void SwitchVelocityY()
    {
        Speed.y = -Speed.y;
    }

}
