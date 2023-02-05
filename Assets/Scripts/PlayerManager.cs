using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public enum CurrentShark { GreatWhite, Hammerhead, Mako }
    [SerializeField]
    public static CurrentShark currentShark;

    public GameObject[] playersharks;
    private int sharkindex;

    [SerializeField]
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < playersharks.Length; i++)
        {
            playersharks[i].SetActive(false);
            sharkindex = 0;
            currentShark = CurrentShark.GreatWhite;
            gameManager.GreatWhite = true;
            gameManager.Hammerhead = false;
            gameManager.Mako = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && gameManager.GreatWhite == false)
        {
            ChangeShark(0);
            currentShark = CurrentShark.GreatWhite;
            gameManager.GreatWhite = true;
            gameManager.Hammerhead = false;
            gameManager.Mako = false;
        }
        if (Input.GetKeyDown(KeyCode.B) && gameManager.Hammerhead == false)
        {
            ChangeShark(1);
            currentShark = CurrentShark.Hammerhead;
            gameManager.GreatWhite = false;
            gameManager.Hammerhead = true;
            gameManager.Mako = false;
        }
        if (Input.GetKeyDown(KeyCode.C) && gameManager.Mako == false)
        {
            ChangeShark(2);
            currentShark = CurrentShark.Mako;
            gameManager.GreatWhite = false;
            gameManager.Hammerhead = false;
            gameManager.Mako = true;
        }
    }

    public void ChangeShark(int indexedshark)
    {
        playersharks[sharkindex].SetActive(false);
        playersharks[indexedshark].SetActive(true);
    }
}
