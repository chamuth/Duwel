using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float LaserSpeed = 10f;
    public float Damage = 0.02f;
    public GameObject Parent = null;

    private float LifeCycle = 5f;

    void Update()
    {
        transform.Translate(new Vector2(Mathf.Sin(transform.eulerAngles.x) * Time.deltaTime * LaserSpeed, Mathf.Cos(transform.eulerAngles.x) * Time.deltaTime * LaserSpeed));

        if (LifeCycle > 0)
        {
            LifeCycle -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
