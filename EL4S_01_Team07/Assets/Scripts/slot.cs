using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum SlotResult
{
    MoreLuck,
    Luck,
    Miss,
}

public class slot : MonoBehaviour
{
     [Header("スロット全体UI")]
    [SerializeField] private GameObject slotPanel;

    [Header("画像")]
    [SerializeField] private Image[] reels;

    [Header("図画像")]
    [SerializeField] private Sprite moreLuckSprite;
    [SerializeField] private Sprite luckSprite;
    [SerializeField] private Sprite missSprite;

    [Header("確率")]
    [SerializeField] private int moreLuckRate = 10;
    [SerializeField] private int luckRate = 50;
    [SerializeField] private int missRate = 40;

    [Header("回転設定")]
    [SerializeField] private float spinInterval = 0.05f;
    [SerializeField] private float stopDelay = 0.75f;
    [SerializeField] private int spinCountBeforeStop = 20;

    [Header("終了後に消えるまでの時間")]
    [SerializeField] private float hideDelay = 3.0f;

    private bool isSpinning;
    public bool IsSpinning => isSpinning;

    // 何にするか
    private Sprite[] symbols;

    private void Awake()
    {
        symbols = new Sprite[]
        {
            moreLuckSprite,
            luckSprite,
            missSprite
        };

        if (slotPanel != null)
        {
            slotPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("スペース押された");

            if (isSpinning) return;

            StartSlot(OnSlotFinished);
        }
    }

    private void OnSlotFinished(SlotResult result)
    {
        switch (result)
        {
            case SlotResult.MoreLuck:
                Debug.Log("大当たり！");
                break;

            case SlotResult.Luck:
                Debug.Log("当たり！");
                break;

            case SlotResult.Miss:
                Debug.Log("ハズレ！");
                break;
        }
    }


    public void StartSlot(Action<SlotResult> onFinished)
    {
        if (isSpinning) return;

        if (slotPanel != null)
        {
            slotPanel.SetActive(true);
        }

        StartCoroutine(SlotCoroutine(onFinished));
    }

    private IEnumerator SlotCoroutine(Action<SlotResult> onFinished)
    {
        isSpinning = true;

        SlotResult result = Lottery();
        Sprite resultSprite = GetSprite(result);

        Coroutine[] reelCoroutines = new Coroutine[reels.Length];

        for (int i = 0; i < reels.Length; i++)
        {
            reelCoroutines[i] = StartCoroutine(SpinReel(i));
        }

        for (int i = 0; i < reels.Length; i++)
        {
            yield return new WaitForSeconds(stopDelay);

            StopCoroutine(reelCoroutines[i]);
            reels[i].sprite = resultSprite;
        }

        yield return new WaitForSeconds(hideDelay);

        if (slotPanel != null)
        {
            slotPanel.SetActive(false);
        }

        isSpinning = false;

        onFinished?.Invoke(result);
    }

    private IEnumerator SpinReel(int reelIndex)
    {
        int count = 0;

        while (true)
        {
            int randomIndex = UnityEngine.Random.Range(0, symbols.Length);
            reels[reelIndex].sprite = symbols[randomIndex];

            count++;

            yield return new WaitForSeconds(spinInterval);
        }
    }

    private SlotResult Lottery()
    {
        int totalRate = moreLuckRate + luckRate + missRate;
        int random = UnityEngine.Random.Range(0, totalRate);

        if (random < moreLuckRate)
        {
            return SlotResult.MoreLuck;
        }

        if (random < moreLuckRate + luckRate)
        {
            return SlotResult.Luck;
        }

        return SlotResult.Miss;
    }

    private Sprite GetSprite(SlotResult result)
    {
        switch (result)
        {
            case SlotResult.MoreLuck:
                return moreLuckSprite;

            case SlotResult.Luck:
                return luckSprite;

            case SlotResult.Miss:
                return missSprite;
        }

        return missSprite;
    }
}
