
public class Mushroom : Enemy
{
    private void Start()
    {
        currentTarget = points[0];
    }

    private void Update()
    {
        Movement();
        SetTarget();
        FlipSprite(GetDirection(currentTarget));
    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
