using UnityEngine;

public class Tree : Bounce
{
    [SerializeField]
    private Animator treeAnimator;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ReducePlayerScale(2f);
            treeAnimator.SetTrigger("Shake");
        }
    }
}
