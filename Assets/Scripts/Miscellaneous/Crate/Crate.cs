using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CrateType
{
    Coin,
    Irony,
    Heart
}

#region REQUIRE_COMPONNET
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
#endregion
public class Crate : MonoBehaviour
{
    [Header("CRATE BOX TYPE")]
    [SerializeField] CrateType crateType;

    [Header("CRATE BOX PROP NUM")]
    [SerializeField] int propNum;

    ParticleSystem normal;
    AudioSource breakAudioSource;
    BoxCollider boxCollider;
    Rigidbody _rigidbody;
    bool isPick;
    const float throwForce = 18.0f;
    const float gravity = 8.0f;

    void Awake()
    {
        LoadComponent();
    }
    void Update()
    {
        CheckPosition();
    }
    void FixedUpdate()
    {
        Gravity();
    }

    void LoadComponent()
    {
        breakAudioSource = gameObject.GetComponent<AudioSource>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        normal = gameObject.GetComponentInChildren<ParticleSystem>();
    }
    void Gravity()
    {
        if (!isPick)
        {
            _rigidbody.AddForce(Physics.gravity * gravity, ForceMode.Acceleration);
        }
    }
    void CheckPosition()
    {
        if (isPick)
        {
            if (gameObject.transform.localPosition != Vector3.zero)
            {
                gameObject.transform.localPosition = Vector3.zero;
            }
            if (gameObject.transform.localRotation != Quaternion.identity)
            {
                gameObject.transform.localRotation = Quaternion.identity;
            }
        }
    }
    void CreateProp()
    {
        switch (crateType)
        {
            case CrateType.Coin:
                CreateCion();
                break;

            case CrateType.Heart:
                CreateHeart();
                break;

            case CrateType.Irony:
                break;
        }
    }
    void CreateCion()
    {
        for (int i = 0; i < propNum; i++)
        {
            GameObject coin = ObjectPoolManager.Instance.GetCoinGO();
            coin.transform.position = gameObject.transform.position;
            if (coin.GetComponent<ShootObject>() != null)
            {
                coin.GetComponent<ShootObject>().Shoot();
            }
            if(coin.GetComponent<Coin>() != null)
            {
                coin.GetComponent<Coin>().PlayCoinAudio(true);
            }
        }
    }
    void CreateHeart()
    {
        for (int i = 0; i < propNum; i++)
        {
            GameObject heart = ObjectPoolManager.Instance.GetHeartGO();
            heart.transform.position = gameObject.transform.position;
            if (heart.GetComponent<ShootObject>() != null)
            {
                heart.GetComponent<ShootObject>().Shoot();
            }
            if(heart.GetComponent<Heart>() != null)
            {
                heart.GetComponent<Heart>().PlayHeartAudio(false);
            }
        }
    }
    void CreateSmoke()
    {
        GameObject smokeGO = ObjectPoolManager.Instance.GetSmokeEffectGO();
        Vector3 temp = gameObject.transform.position;
        temp.y += 0.5f;
        smokeGO.transform.position = temp;
    }
    void Shoot(Vector3 direction)
    {
        if(direction.sqrMagnitude > 0)
        {
            _rigidbody.velocity = direction * throwForce;
        }
    }

    public void Explosion()
    {
        if(crateType == CrateType.Irony)
        {
            return;
        }

        AudioManager.Instance.PlayAudio(breakAudioSource.clip);
        normal?.Stop();
        CreateSmoke();
        CreateProp();
        Destroy(gameObject);
    }
    public void ForceExplosion()
    {
        AudioManager.Instance.PlayAudio(breakAudioSource.clip);
        normal?.Stop();
        CreateSmoke();
        CreateProp();
        Destroy(gameObject);
    }
    public void PickUp(Transform _transform)
    {
        isPick = true;
        _rigidbody.isKinematic = true;
        boxCollider.enabled = false;
        gameObject.transform.parent = _transform;
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = Quaternion.identity;
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }
    public void Throw(Transform _transform)
    {
        isPick = false;
        _rigidbody.isKinematic = false;
        boxCollider.enabled = true;
        gameObject.transform.parent = GameManager.Instance.LevelTransform;
        _rigidbody.constraints = RigidbodyConstraints.None;
        Shoot((gameObject.transform.position - _transform.position).normalized);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(Setting.TagSlime))
        {
            if(collision.gameObject.GetComponent<Slime>() != null)
            {
                if(_rigidbody.velocity.sqrMagnitude > Setting.CatreColldierCreateDamageMinSpeed)
                {
                    Slime slime = collision.gameObject.GetComponent<Slime>();
                    if(slime.Health.DecreaseHealth(1) <= 0)
                    {
                        slime.IsDead = true;
                    }
                }
            }
        }
        else if(collision.gameObject.CompareTag(Setting.Player))
        {
            boxCollider.material = GameResourceManager.Instance.SmoothPhysicMaterial;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(Setting.Player))
        {
            boxCollider.material = null;
        }
    }
}
