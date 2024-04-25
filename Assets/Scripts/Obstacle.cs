using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float Movespeed = 3.5f;

    private void Update()
    {
        this.transform.Translate(Vector3.back * Movespeed * Time.deltaTime);
        if(this.transform.position.z < -10) Destroy(this.gameObject);
    }
}
