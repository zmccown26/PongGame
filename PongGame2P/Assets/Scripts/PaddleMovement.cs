using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 10f;
    public string upKey = "w";
    public string downKey = "s";

    float halfHeight;
    float yMin, yMax;

    void Start()
    {
        // compute half-height from sprite bounds (works for SpriteRenderer)
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr) halfHeight = sr.bounds.extents.y;
        else halfHeight = transform.localScale.y / 2f;

        float vertExtent = Camera.main.orthographicSize;
        yMin = -vertExtent + halfHeight;
        yMax = vertExtent - halfHeight;
    }

    void Update()
    {
        float move = 0f;
        if (Input.GetKey(upKey)) move = 1f;
        if (Input.GetKey(downKey)) move = -1f;

        transform.Translate(Vector2.up * move * speed * Time.deltaTime);

        // clamp to camera vertical bounds
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, yMin, yMax);
        transform.position = pos;
    }
}

