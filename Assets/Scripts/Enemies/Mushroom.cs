
public class Mushroom : Enemy
{
    private void Start()
    {
        targetPoint = points[0];
    }

    private void Update()
    {
        Movement();
        SetTarget();
        FlipSprite(GetDirection(targetPoint));
    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }
    
}
