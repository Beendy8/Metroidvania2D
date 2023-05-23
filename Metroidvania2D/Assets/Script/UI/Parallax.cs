using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField, Range(0f, 1f)] float parallaxStreght = 0.1f;
    [SerializeField] bool disableVectivalParallax;
    Vector3 targetPosition;

    private void Start()
    {
        if (!followTarget)
        {
            followTarget = Camera.main.transform;
            targetPosition = followTarget.position;
        }
    }

    private void Update()
    {
        var delta = followTarget.position - targetPosition;
        if (disableVectivalParallax)
        {
            delta.y = 0;

        }
        targetPosition = followTarget.position;
        transform.position += delta * parallaxStreght;
    }
}
