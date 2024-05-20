using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBird : Enemy
{
    private void Update()
    {
        Movement();
    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
