using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

	[SerializeField] protected float objectSpeed = 1;
	[SerializeField] protected float offscreenPosition = -28.43f;
    [SerializeField] protected float startPosition = 48.25f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if (!GameManager.instance.GameOver && GameManager.instance.PlayerActive)
        {
            transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

            if (transform.localPosition.x <= offscreenPosition)
            {
                Vector3 newPosition = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newPosition;
            }
        }
    }

}
