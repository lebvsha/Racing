using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarController : MonoCache
{
    [SerializeField] private WheelJoint2D _backWheel;
    [SerializeField] private WheelJoint2D _frontWheel;
    private float _currSpeed = 0;
    public bool _moveFarward = false;
    public bool _moveBackward = false;
    private JointMotor2D _motor;
    private bool _isGrounded = false;
    private Rigidbody2D _rb;
    public Image Bar;
    public float _health = 100f;
    public Image Pedal1;
    public Image Pedal2;
    public Sprite[] Pedals = new Sprite[1];
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health -= value;
            Bar.fillAmount -= value/100;
        }
    }


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _motor.maxMotorTorque = 5000;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(FuelReducer());
    }

    public override void OnTick()
    {
        CheckGameOver();
        if (_frontWheel.GetComponent<Collider2D>().IsTouchingLayers() ||
            _backWheel.GetComponent<Collider2D>().IsTouchingLayers())
            _isGrounded = true;
        else
            _isGrounded = false;
    }

    public void Right() 
    {
        _moveBackward = false;
        _moveFarward = true;
        Pedal1.sprite = Pedals[0];
    }

    public void Left()
    {
        _moveBackward = true;
        _moveFarward = false;
        Pedal2.sprite = Pedals[0];
    }

    public override void OnFixedTick()
    {
        MoveOnGround();
        if (!_isGrounded)
        {
            MoveOnAir();
        }
    }

    private void MoveOnAir()
    {
        _frontWheel.useMotor = false;
        _backWheel.useMotor = false;
        if (_frontWheel.attachedRigidbody.angularVelocity < 200)
            _rb.AddTorque(4f);
        
        if (_frontWheel.attachedRigidbody.angularVelocity > -200)
            _rb.AddTorque(-4f);
    }

    private void MoveOnGround() 
    {
        if (_moveFarward)
        {
            if (_frontWheel.attachedRigidbody.angularVelocity > -2000)
            {
                _currSpeed += 30;
                _motor.motorSpeed = _currSpeed;
            }

            _frontWheel.motor = _motor;
            _backWheel.motor = _motor;
            _frontWheel.useMotor = true;
            _backWheel.useMotor = true;

        }
        else if (_moveBackward)
        {
            if (_frontWheel.attachedRigidbody.angularVelocity < 2000)
            {
                _currSpeed -= 30;
                _motor.motorSpeed = _currSpeed;
            }
            _frontWheel.motor = _motor;
            _backWheel.motor = _motor;
            _frontWheel.useMotor = true;
            _backWheel.useMotor = true;
        }
        else
        {
            _currSpeed = -_frontWheel.attachedRigidbody.angularVelocity;
            _frontWheel.useMotor = false;
            _backWheel.useMotor = false;
        }
    }

    private void CheckGameOver()
    {
        Vector2 rayDir = transform.up;
        RaycastHit2D[] raycastHit = Physics2D.RaycastAll(transform.position, rayDir, 0.7f);
        Debug.DrawRay(transform.position,rayDir * 0.7f, Color.green);
        if (raycastHit.Length > 1 || _health <= 0)
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GameOver")) 
        {
            GameOver();
        }
        if (collision.CompareTag("Fuel")) 
        {
            Destroy(collision.gameObject);
            Bar.fillAmount = 1;
            _health = 100f;
        }
    }

    private void GameOver()
    {
        _frontWheel.useMotor = false;
        _backWheel.useMotor = false;
        Time.timeScale = 0f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator FuelReducer() 
    {
        while (Health >= 0)
        {
            yield return new WaitForSeconds(0.5f);
            Health = 1f;
        }
    }
}
