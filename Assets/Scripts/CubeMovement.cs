using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float Speed { get; set; }
    public float Distance { get; set; }

    private void Awake()
    {
        Speed = GlobalCubeVars.Speed;
        Distance = GlobalCubeVars.Distance;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.right * Distance, Time.deltaTime * Speed);

        if (transform.position.x >= Distance)
        {
            Destroy(gameObject);
        }
    }
}