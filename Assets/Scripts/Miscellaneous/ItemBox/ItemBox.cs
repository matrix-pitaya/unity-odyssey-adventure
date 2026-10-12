using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [Header("ITEM BOX PROP NUM")]
    [SerializeField] int propNum;

    [Header("ITEM BOX EMPTY MATERIAL")]
    [SerializeField] Material greyMaterial;

    MeshRenderer meshRenderer;

    void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
    }
    void Create(Player player)
    {
        GameObject coinGO = ObjectPoolManager.Instance.GetItemBoxCoinGO();
        coinGO.transform.position = gameObject.transform.position;
        propNum--;
        if (propNum <= 0)
        {
            Grey();
        }
        player.PlayerParticle.PlayParticleSystem(PlayerParticleType.Stars);
        UIManager.Instance.UpdataCoinsNumUI(PlayerGameDataManager.Instance.AddCoins(1));
    }
    void Grey()
    {
        meshRenderer.material = greyMaterial;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(Setting.Player))
        {
            if(collision.contacts.Length > 0)
            {
                if(collision.contacts[0].normal.y > 0 && propNum > 0)
                {
                    if(collision.gameObject.GetComponent<Player>() != null)
                    {
                        Create(collision.gameObject.GetComponent<Player>());
                    }
                }
            }
        }
    }
}
