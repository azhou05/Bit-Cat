using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector2 startPos;
    private float lengthX;
    private float lengthY;
    public Camera cam;
    public Vector2 parallaxEffect; // x = horizontal effect, y = vertical effect

    void Start()
    {
        startPos = transform.position;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        Vector2 temp = new Vector2(
            cam.transform.position.x * (1 - parallaxEffect.x),
            cam.transform.position.y * (1 - parallaxEffect.y)
        );

        Vector2 dist = new Vector2(
            cam.transform.position.x * parallaxEffect.x,
            cam.transform.position.y * parallaxEffect.y
        );

        transform.position = new Vector3(startPos.x + dist.x, startPos.y + dist.y, transform.position.z);

        // Optional: Infinite scrolling logic
        if (Mathf.Abs(temp.x - startPos.x) >= lengthX)
{
    float offsetX = (temp.x - startPos.x) % lengthX;
    startPos.x = cam.transform.position.x + offsetX;
}

        if (temp.y > startPos.y + lengthY) startPos.y += lengthY;
        else if (temp.y < startPos.y - lengthY) startPos.y -= lengthY;
    }
}