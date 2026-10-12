using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[DisallowMultipleComponent]
public class ObjectPoolManager : SingletenMonoBehaviour<ObjectPoolManager>
{
    [Header("ITEMBOX COIN POOL INFORMATION")]
    [SerializeField] GameObject itemBoxCoinPrefab;
    [SerializeField] Transform itemBoxCoinTransform;
    ObjectPool<GameObject> itemBoxCoinPool;

    [Header("COIN POOL INFORMATION")]
    [SerializeField] GameObject coinPrefab;
    [SerializeField] Transform coinTransform;
    ObjectPool<GameObject> coinPool;

    [Header("SMOKE POOL INFORMATION")]
    [SerializeField] GameObject smokePrefab;
    [SerializeField] Transform smokeTransform;
    ObjectPool<GameObject> smokePool;

    [Header("STAR EFFECT POOL INFORMATION")]
    [SerializeField] GameObject starEffectPrefab;
    [SerializeField] Transform starEffectTransform;
    ObjectPool<GameObject> starEffectPool;

    [Header("HEART POOL INFORMATION")]
    [SerializeField] GameObject heartPrefab;
    [SerializeField] Transform heartTransform;
    ObjectPool<GameObject> heartPool;

    [Header("HEART EFFECT POOL INFORMATION")]
    [SerializeField] GameObject heartEffectPrefab;
    [SerializeField] Transform heartEffectTransform;
    ObjectPool<GameObject> heartEffectPool;

    [Header("FLASH EFFECT POOL")]
    [SerializeField] GameObject flashEffectPrefab;
    [SerializeField] Transform flashEffectTransform;
    ObjectPool<GameObject> flashEffectPool;

    protected override void Awake()
    {
        base.Awake();
        InitObjectPool();
    }

    void InitObjectPool()
    {
        itemBoxCoinPool = new ObjectPool<GameObject>(ActionOnCreateItemBoxCoinGO, ActionOnGetItemBoxCoinGO, ActionOnReleaseItemBoxCoinGO, ActionOnDestroyItemBoxCoinGO);
        coinPool = new ObjectPool<GameObject>(ActionOnCreateCoinGO, ActionOnGetCoinGO, ActionOnReleaseCoinGO, ActionOnDestoryCoinGO);
        smokePool = new ObjectPool<GameObject>(ActionOnCreateSmokeGO, ActionOnGetSmokeGO, ActionOnReleaseSmokeGO, ActionOnDestroySmokeGO);
        heartPool = new ObjectPool<GameObject>(ActionOnCreateHeartGO, ActionOnGetHeartGO, ActionOnReleaseHeartGO, ActionOnDestroyHeartGO);
        starEffectPool = new ObjectPool<GameObject>(ActionOnCreateStarEffectGO, ActionOnGetStarEffectGO, ActionOnReleaseStarEffectGO, ActionOnDestroyStarEffectGO);
        heartEffectPool = new ObjectPool<GameObject>(ActionOnCreateHeartEffectGO, ActionOnGetHeartEffectGO, ActionOnReleaseHeartEffectGO, ActionOnDestroyHeartEffectGO);
        flashEffectPool = new ObjectPool<GameObject>(ActionOnCreateFlashEffectGO, ActionOnGetFlashEffectGO, ActionOnReleaseFlashEffectGO, ActionOnDestroyFlashEffectGO);
    }

    GameObject ActionOnCreateItemBoxCoinGO()
    {
        return Instantiate(itemBoxCoinPrefab, itemBoxCoinTransform);
    }
    void ActionOnGetItemBoxCoinGO(GameObject itemBoxCoinGO)
    {
        itemBoxCoinGO.SetActive(true);
    }
    void ActionOnReleaseItemBoxCoinGO(GameObject itemBoxCoinGO)
    {
        itemBoxCoinGO.SetActive(false);
    }
    void ActionOnDestroyItemBoxCoinGO(GameObject itemBoxCoinGO)
    {
        
    }
    GameObject ActionOnCreateCoinGO()
    {
        return Instantiate(coinPrefab, coinTransform);
    }
    void ActionOnGetCoinGO(GameObject crateCoinGO)
    {
        crateCoinGO.SetActive(true);
    }
    void ActionOnReleaseCoinGO(GameObject crateCoinGO)
    {
        crateCoinGO.SetActive(false);
    }
    void ActionOnDestoryCoinGO(GameObject crateCoinGO)
    {
    
    }
    GameObject ActionOnCreateSmokeGO()
    {
        return Instantiate(smokePrefab, smokeTransform);
    }
    void ActionOnGetSmokeGO(GameObject smokeGO)
    {
        smokeGO.SetActive(true);
    }
    void ActionOnReleaseSmokeGO(GameObject smokeGO)
    {
        smokeGO.SetActive(false);
    }
    void ActionOnDestroySmokeGO(GameObject smokeGO)
    {

    }
    GameObject ActionOnCreateHeartGO()
    {
        return Instantiate(heartPrefab, heartTransform);
    }
    void ActionOnGetHeartGO(GameObject heartGO)
    {
        heartGO.SetActive(true);
    }
    void ActionOnReleaseHeartGO(GameObject heartGO)
    {
        heartGO.SetActive(false);
    }
    void ActionOnDestroyHeartGO(GameObject heartGO)
    {

    }
    GameObject ActionOnCreateStarEffectGO()
    {
        return Instantiate(starEffectPrefab, starEffectTransform);
    }
    void ActionOnGetStarEffectGO(GameObject starEffectGO)
    {
        starEffectGO.SetActive(true);
    }
    void ActionOnReleaseStarEffectGO(GameObject starEffectGO)
    {
        starEffectGO.SetActive(false);
    }
    void ActionOnDestroyStarEffectGO(GameObject starEffectGO)
    {

    }
    GameObject ActionOnCreateHeartEffectGO()
    {
        return Instantiate(heartEffectPrefab, heartEffectTransform);
    }
    void ActionOnGetHeartEffectGO(GameObject heartEffectGO)
    {
        heartEffectGO.SetActive(true);
    }
    void ActionOnReleaseHeartEffectGO(GameObject heartEffectGO)
    {
        heartEffectGO.SetActive(false);
    }
    void ActionOnDestroyHeartEffectGO(GameObject flashEffectGO)
    {

    }
    GameObject ActionOnCreateFlashEffectGO()
    {
        return Instantiate(flashEffectPrefab, flashEffectTransform);
    }
    void ActionOnGetFlashEffectGO(GameObject flashEffectGO)
    {
        flashEffectGO.SetActive(true);
    }
    void ActionOnReleaseFlashEffectGO(GameObject flashEffectGO)
    {
        flashEffectGO.SetActive(false);
    }
    void ActionOnDestroyFlashEffectGO(GameObject flashEffectGO)
    {

    }

    public GameObject GetItemBoxCoinGO()
    {
        return itemBoxCoinPool.Get();
    }
    public void ReleaseItemBoxCoinGO(GameObject itemBoxCoinGO)
    {
        itemBoxCoinPool.Release(itemBoxCoinGO);
    }
    public GameObject GetCoinGO()
    {
        return coinPool.Get();
    }
    public void ReleaseCoinGO(GameObject coinGO)
    {
        coinPool.Release(coinGO);
    }
    public GameObject GetSmokeEffectGO()
    {
        return smokePool.Get();
    }
    public void ReleaseSmokeEffectGO(GameObject smokeGO)
    {
        smokePool.Release(smokeGO);
    }
    public GameObject GetHeartGO()
    {
        return heartPool.Get();
    }
    public void ReleaseHeartGO(GameObject heartGO)
    {
        heartPool.Release(heartGO);
    }
    public GameObject GetStarEffectGO()
    {
        return starEffectPool.Get();
    }
    public void ReleaseStarEffectGo(GameObject starEffectGO)
    {
        starEffectPool.Release(starEffectGO);
    }
    public GameObject GetHeartEffectGO()
    {
        return heartEffectPool.Get();
    }
    public void ReleaseHeartEffectGO(GameObject heartEffectGO)
    {
        heartEffectPool.Release(heartEffectGO);
    }
    public GameObject GetFlashEffectGO()
    {
        return flashEffectPool.Get();
    }
    public void ReleaseFlashEffectGO(GameObject flashEffectGO)
    {
        flashEffectPool.Release(flashEffectGO);
    }
}
