using UnityEngine;
using System.Collections;

public class Camera_Control : MonoBehaviour
{

    [SerializeField]
    Transform character;

    private Vector3 moveTemp;

    [SerializeField]
    float speed = 3;
    [SerializeField]
    float xDifference;
    [SerializeField]
    float yDifference;
    [SerializeField]
    float moveThreshold;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.position.x > transform.position.x)
        {
            xDifference = character.transform.position.x - transform.position.x;
        }
        else
        {
            xDifference = transform.position.x - character.transform.position.x;
        }



        if (character.transform.position.y > transform.position.y)
        {
            yDifference = character.transform.position.y - transform.position.y;
        }
        else
        {
            yDifference = transform.position.y - character.transform.position.y;
        }

        if (yDifference <= 1.5f)
        {
            moveTemp = character.transform.position;
            moveTemp.y = 1;
        }

        if (yDifference >= 2f)
        {
            moveTemp.y = character.transform.position.y;
        }

        if (xDifference >= moveThreshold || yDifference >= moveThreshold )
        {
           
            transform.position = Vector3.MoveTowards(transform.position, moveTemp, speed * Time.deltaTime);
        }
    }

    
}