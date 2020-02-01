using UnityEngine;

public class Connector : MonoBehaviour
{
    public Rigidbody2D ParentRigidBody;

    public float PullForce = 1f;
    public float PullDistance = 0.5f;

    private void Update()
    {
        if (!IsControllable)
            return;

        foreach (var connector in FindObjectsOfType<Connector>())
        {
            if (connector.transform.root == transform.root)
                continue;

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
        magneticForce = Vector2.ClampMagnitude(magneticForce, 10);

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
        if (!IsControllable)
            return;

        var connector = other.gameObject.GetComponent<Connector>();
        if (connector == null)
            return;

        ParentRigidBody.gameObject.AddComponent<FixedJoint2D>().connectedBody = connector.ParentRigidBody;
        var otherParent = connector.transform.root.gameObject;

        var parentControllable = otherParent.GetComponent<Controllable>();
        if (parentControllable == null)
            parentControllable = otherParent.AddComponent<Controllable>();

        parentControllable.IsControllable = true;

        Destroy(connector.gameObject);
        Destroy(gameObject);
    }

    private bool IsControllable
    {
        get
        {
            var controllableComponent = GetComponentInParent<Controllable>();
            return controllableComponent != null && controllableComponent.IsControllable;
        }
    }
}
