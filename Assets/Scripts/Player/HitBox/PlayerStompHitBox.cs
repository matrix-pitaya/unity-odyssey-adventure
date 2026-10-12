using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerStompHitBox : MonoBehaviour
{
    BoxCollider boxCollider;

    public BoxCollider BoxCollider
    {
        get
        {
            return boxCollider;
        }
    }

    void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Setting.TagCrate))
        {
            if (other.gameObject.GetComponent<Crate>() != null)
            {
                other.gameObject.GetComponent<Crate>().Explosion();
            }
        }
        else if (other.gameObject.CompareTag(Setting.TagSlime))
        {
            if (other.gameObject.GetComponent<Slime>() != null)
            {
                Slime slime = other.gameObject.GetComponent<Slime>();
                if(slime.Health.DecreaseHealth(1) <= 0)
                {
                    slime.IsDead = true;
                }
            }
        }
    }
}
