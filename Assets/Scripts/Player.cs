using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public enum Controller
    {
        Keyboard, Joystick
    }

    public Controller InputType;

    [Header("Player Properties")]
    public float Health = 1f;
    public float MovementSpeed = 50f;
    public float TurnSpeed = 100f;
    public int Score = 0;
    public float LaserDelay = 0.05f;

    [Header("GameObject Connections")]
    public Text PlayerScore;

    [Header("Prefab Connections")]
    public GameObject LaserBullet;

    private Rigidbody2D rb2;
    private float _laserDelay = 0;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShootLaser()
    {
        Instantiate(LaserBullet, transform.position, transform.rotation);
    }

    public void Update()
    {
        switch (InputType)
        {
            case Controller.Keyboard:
                #region Player Movements

                if (Input.GetKey(KeyCode.W))
                    rb2.AddForce(new Vector3(0, Time.deltaTime * MovementSpeed));
                if (Input.GetKey(KeyCode.A))
                    rb2.AddForce(new Vector3(-Time.deltaTime * MovementSpeed, 0));
                if (Input.GetKey(KeyCode.S))
                    rb2.AddForce(new Vector3(0, -Time.deltaTime * MovementSpeed));
                if (Input.GetKey(KeyCode.D))
                    rb2.AddForce(new Vector3(Time.deltaTime * MovementSpeed, 0));

                #endregion

                #region Player Direction

                if (Input.GetKey(KeyCode.LeftArrow))
                    gameObject.transform.Rotate(new Vector3(0, 0, Time.deltaTime * TurnSpeed));
                if (Input.GetKey(KeyCode.RightArrow))
                    gameObject.transform.Rotate(new Vector3(0, 0, Time.deltaTime * -TurnSpeed));

                #endregion

                #region Laser Shooting

                if (Input.GetKey(KeyCode.Space))
                {
                    if (_laserDelay <= 0)
                    {
                        ShootLaser();
                        _laserDelay = LaserDelay;
                    }
                }

                if (_laserDelay > 0)
                {
                    _laserDelay -= Time.deltaTime;
                }
                #endregion

                break;
            case Controller.Joystick:
                #region Player Movements
                rb2.AddForce(new Vector3(0, Time.deltaTime * MovementSpeed * Input.GetAxis("Vertical")));
                rb2.AddForce(new Vector3(Time.deltaTime * Input.GetAxis("Horizontal") * MovementSpeed, 0));
                #endregion

                #region Player Direction
                gameObject.transform.Rotate(new Vector3(0, 0, Time.deltaTime * TurnSpeed * -Input.GetAxis("Rotate")));
                #endregion

                #region Laser Shooting

                if (Input.GetKey(KeyCode.Joystick1Button5)) // RT
                {
                    if (_laserDelay <= 0)
                    {
                        ShootLaser();
                        _laserDelay = LaserDelay;
                    }
                }

                if (_laserDelay > 0)
                {
                    _laserDelay -= Time.deltaTime;
                }
                #endregion

                break;
        }
    }
}
