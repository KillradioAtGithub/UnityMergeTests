using UnityEngine;
using System.Collections;

public class BoundingSystem : MonoBehaviour {

    public bool BounceOnWall;

    private float ScreenWidth;
    private float ScreenHeight;
    private Vector3 position;

    public void Start()
    {
        ScreenHeight = Camera.mainCamera.orthographicSize * 2;
        ScreenWidth = ScreenHeight * Camera.mainCamera.aspect;
    }
	
	public void Update () 
    {
        position = transform.position;
        position.x = CheckWall(position.x, ScreenWidth / 2, -ScreenWidth / 2, gameObject.GetComponent<MovementSystem>().SwitchVelocityX, transform.localScale.x / 2);
        position.y = CheckWall(position.y, ScreenHeight / 2, -ScreenHeight / 2, gameObject.GetComponent<MovementSystem>().SwitchVelocityY, transform.localScale.y / 2);
        transform.position = position;
	}

    private float CheckWall(float actualPosition, float max, float min, System.Action action, float offset = 0)
    {
        if (actualPosition >= max - offset)
        {
            if (BounceOnWall)
                action();
            else
                return max - offset;
        }
        else if (actualPosition <= min + offset)
        {
            if (BounceOnWall)
                action();
            else
                return min + offset;
        }
        return actualPosition;
    }

}
