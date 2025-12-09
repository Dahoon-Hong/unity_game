using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using System;

public class CardSelector : MonoBehaviour
{
    private List<CardData> cardData;
    public GameObject cardPrefab;

    [SerializeField]
    private int numberOfCardSelection;

    [SerializeField]
    private float distanceBetweenCards = 3.0f;

    private List<GameObject> candidateCards = new List<GameObject>();

    void Awake()
    {
        this.enabled = false; // Disable the component when it awakens
    }

    private void OnEnable()
    {
        SpawnCard();
    }


    private void OnDisable()
    {

    }

    

    private void Start()
    {
        Card.OnClicked += CardSelected;
        Debug.Log("load cards");
        LoadCardData();
    }

    private void LoadCardData()
    {
        TextAsset cardJson = Resources.Load<TextAsset>("card");
        if (cardJson != null)
        {
            cardData = JsonUtility.FromJson<CardDataListWrapper>(cardJson.text).contents;
            Debug.Log("Card data loaded successfully.");
        }
        else
        {
            Debug.LogError("card.json not found in Resources folder!");
        }
    }

    private List<CardData> GetRandomCards(int count)
    {
        if (cardData == null || cardData.Count == 0)
        {
            Debug.LogError("Card data is not loaded or empty.");
            LoadCardData();
        }

        // Simple random selection
        var random = new System.Random();
        return cardData.OrderBy(x => random.Next()).Take(count).ToList();
    }

    
    private void SpawnCard()
    {
        // First, clear any existing cards to prevent duplicates when re-enabled.
        CleanupCards();

        List<CardData> randomCards = GetRandomCards(numberOfCardSelection);
        int numToSpawn = randomCards.Count;

        if (numToSpawn == 0)
        {
            return;
        }
        
        for (int i = 1; i <= numToSpawn; i++)
        {
            var cardData = randomCards[i-1];
            int offset = i%2==0?1:-1;
            float xPos = (float)Math.Floor((double)i/2) * distanceBetweenCards * offset;
            Vector3 spawnPos = new Vector3(xPos, 0, 0);

            // Instantiate the card and set its parent and position.
            GameObject card = Instantiate(cardPrefab, transform);
            card.transform.localPosition = spawnPos;

            card.GetComponent<Card>().data = cardData;
            candidateCards.Add(card);
        }
    }

    private void CleanupCards()
    {
        foreach (var card in candidateCards)
        {
            Destroy(card);
        }
        candidateCards.Clear();
    }
        

    private void CardSelected(Card card, PointerEventData eventData)
    {
        Debug.Log("Card Selected!");
        CleanupCards();
    }
    
}

// Helper class to wrap the list of CardData for JSON deserialization
[System.Serializable]
public class CardDataListWrapper
{
    public List<CardData> contents;
}
