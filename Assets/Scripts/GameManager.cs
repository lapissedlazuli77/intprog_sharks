using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mackerel;

    public bool GreatWhite = true;
    public bool Hammerhead = false;
    public bool Mako = false;

    [SerializeField]
    PlayerManager player;
    [SerializeField]
    TextMeshProUGUI textgwscore;
    [SerializeField]
    TextMeshProUGUI texthscore;
    [SerializeField]
    TextMeshProUGUI textmscore;

    private int initialmackerel = 20;

    public int gwscore = 0;
    public int hscore = 0;
    public int mscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initialmackerel; i++)
        {
            SpawnFish();
        }
    }

    // Update is called once per frame
    void Update()
    {
        textgwscore.text = "<color=#428386>Great White: </color>" + gwscore;
        texthscore.text = "<color=#9978AC>Hammerhead: </color>" + hscore;
        textmscore.text = "<color=#00107D>Mako: </color>" + mscore;

        if (GreatWhite == false) { player.playersharks[0].SetActive(false); }
        if (Hammerhead == false) { player.playersharks[1].SetActive(false); }
        if (Mako == false) { player.playersharks[2].SetActive(false); }
    }
    void SpawnFish()
    {
        GameObject newFish = Instantiate(mackerel);
        newFish.transform.position = new Vector3(Random.Range(-11f, 11f), 1, Random.Range(-9f, 9f));
    }
}
