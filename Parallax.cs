using UnityEngine;

public class Parallax : MonoCache
{
    private float _lenght, _startPos;
    public GameObject Cam;
    public float ParallaxEffect;
    public float Delta;

    private void Start()
    {
        _startPos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    public override void OnTick()
    {
        float dist = Cam.transform.position.x * ParallaxEffect;
        transform.position = new Vector3(_startPos + dist, Cam.transform.position.y + Delta, transform.position.z);
        float temp = Cam.transform.position.x * (1 - ParallaxEffect);
        if (temp > _startPos + _lenght)
            _startPos += _lenght;
        else if(temp > _startPos + _lenght)
            _startPos -= _lenght;
    }
}
