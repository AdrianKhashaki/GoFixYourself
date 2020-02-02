using UnityEngine;

public class Connector : MonoBehaviour
{
    public Rigidbody2D ParentRigidBody;
 

    public float PullForce = 3000f;
    
    private void Update()
    {
        if (this.GetPlayerAffinity() == 0)
            return;

        foreach (var connector in FindObjectsOfType<Connector>())
        {
            if (connector.GetPlayerAffinity() == 0)
                Attract(connector);
        }
    }

    private void OnValidate()
    {
        if (ParentRigidBody != null)
            return;

        var parent = transform.parent;
        if (parent == null)
            return;

        ParentRigidBody = parent.GetComponent<Rigidbody2D>();
    }

    private void Attract(Connector connector)
    {
        var magneticForce = CalculateMagneticForce(connector);

        ParentRigidBody.AddForce(magneticForce);
        connector.ParentRigidBody.AddForce(-magneticForce);
    }

    private Vector2 CalculateMagneticForce(Component other)
    {
        var directionToOther = other.transform.position - transform.position;

        return directionToOther.normalized * PullForce / directionToOther.sqrMagnitude;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var connector = other.gameObject.GetComponent<Connector>();
        if (connector == null)
            return;
        
        if (other.GetPlayerAffinity() != 0 || this.GetPlayerAffinity() == 0)
            return;

        ParentRigidBody.gameObject.AddComponent<FixedJoint2D>().connectedBody = connector.ParentRigidBody;

        connector.SetPlayerAffinity(this.GetPlayerAffinity());

        Destroy(connector.gameObject);
        Destroy(gameObject);
    }
}