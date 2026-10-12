using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[DisallowMultipleComponent]
public class HideCoinTrigger : MonoBehaviour
{
    BoxCollider boxCollider;

    void Awake()
    {
        LoadComponnet();
    }

    void LoadComponnet()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }
    void CreateCoin()
    {
        GameObject itemBoxCoin = ObjectPoolManager.Instance.GetItemBoxCoinGO();
        itemBoxCoin.transform.position = gameObject.transform.position;
        GameManager.Instance.Player.PlayerParticle.PlayParticleSystem(PlayerParticleType.Stars);
        UIManager.Instance.UpdataCoinsNumUI(PlayerGameDataManager.Instance.AddCoins(1));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Setting.Player))
        {
            CreateCoin();
            boxCollider.enabled = false;
        }
    }
}
