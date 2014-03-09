using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScrollingScript : MonoBehaviour
{
    #region Designer variables

    /// <summary>
    /// Scrolling speed
    /// </summary>
    public Vector2 speed = new Vector2(2, 2);
    /// <summary>
    /// Direction of movement
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);
    /// <summary>
    /// Whether the movement should be applied to the camera
    /// </summary>
    public bool isLinkedToCamera = false;
    /// <summary>
    /// Whether or not to loop the scrolling area
    /// </summary>
    public bool isLooping = false;

    #endregion

    private List<Transform> backgroundPart;

    void Start()
    {
        if (isLooping)
        {
            backgroundPart = new List<Transform>();

            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                if (child.renderer != null)
                {
                    backgroundPart.Add(child);
                }
            }

            backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();
        }
    }

    void Update()
    {
        Vector3 movement = new Vector3(
                                   speed.x * direction.x,
                                   speed.y * direction.y,
                                   0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        if (isLooping)
        {
            Transform firstChild = backgroundPart.FirstOrDefault();
            if (firstChild != null)
            {
                var xpos = firstChild.transform.position.x 
                    + (firstChild.renderer.bounds.max - firstChild.renderer.bounds.min).x;
                if (xpos < Camera.main.transform.position.x)
                {
                    Transform lastChild = backgroundPart.LastOrDefault();
                    Vector3 lastPosition = lastChild.transform.position;
                    Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

                    firstChild.position = new Vector3(
                        lastPosition.x + lastSize.x,
                        lastPosition.y,
                        firstChild.position.z
                    );

                    backgroundPart.Remove(firstChild);
                    backgroundPart.Add(firstChild);
                }
            }
        }
    }
}
