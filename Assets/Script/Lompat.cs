using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lompat : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Sprite deadSprite;
    private int spriteIndex;
    private Vector3 direction;
    [SerializeField] private float _Velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;
    public bool IsAlive = true;
    public GameObject gameOverMenu;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Show()
    {
        gameOverMenu.SetActive(true);
    }

    public void Hide()
    {
        gameOverMenu.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        IsAlive = false;
        Time.timeScale = 0;
        Show();
        spriteRenderer.sprite = deadSprite;
    }
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Hide();
        IsAlive = true;
        Time.timeScale = 1;
        InvokeRepeating(nameof(AnimatedSprite), 0.15f, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _rb.velocity = Vector2.up * _Velocity;
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }
    private void AnimatedSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
