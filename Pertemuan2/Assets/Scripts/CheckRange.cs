using UnityEngine;

public class CheckRange : Condition
{
    [Header("Stats")]
    public float minRadius;
    public float maxRadius;

    private GameObject playerObj;
    public void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    public override bool CheckCondition()
    {
        //float playerPOS = playerObj.transform.position.normalized;
        //float enemyPOS = transform.position.normalized;

        float distance = Vector3.Distance(playerObj.transform.position, this.transform.position);
        //if (playerPOS - enemyPOS >= minRadius && playerPOS - enemyPOS <= maxRadius)
        if (distance >= minRadius && distance <= maxRadius)
        {
            return true;
        }
        return false;
    }
}
