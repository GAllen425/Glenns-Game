using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MovingObject {

    [SerializeField] Vector3 topPosition;
    [SerializeField] Vector3 bottomPosition;
    [SerializeField] float waitTime;
    [SerializeField] float speed;
    [SerializeField] AudioSource audioSource;

    [SerializeField] private float randSpeedMultipler;
    // Use this for initialization
    void Start () {
        //starts at top so move towards bottom
        randSpeedMultipler = 1.0f;
        StartCoroutine(Move(bottomPosition));
    }

    protected override void Update()
    {
        if (!GameManager.instance.GameOver && GameManager.instance.PlayerActive)
        { 
            transform.Translate(Vector3.forward * (objectSpeed * Time.deltaTime));

            if (transform.localPosition.x <= offscreenPosition)
            {
                Vector3 newPosition = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newPosition;
                randSpeedMultipler = Random.Range(0.1f, 3.5f);
            }

            audioSource.panStereo = Mathf.Abs(transform.localPosition.x - offscreenPosition)/(startPosition-offscreenPosition) * 2 - 1;
        }
    }

    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * speed * randSpeedMultipler *Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        StartCoroutine(Move(newTarget));
    }
}
