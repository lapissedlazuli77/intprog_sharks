using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using static Player;

public class PlayerShark : MonoBehaviour
{
    public enum CurrentShark { GreatWhite, Hammerhead, Mako }
    [SerializeField]
    CurrentShark currentShark = CurrentShark.GreatWhite;

    public GameObject[] playersharks;
    private int sharkindex;

    private Vector3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < playersharks.Length; i++)
        {
            playersharks[i].SetActive(false);
            sharkindex = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 newPos = Vector3.zero;
        Vector3 targetDirection = currentTarget - transform.position;
        Vector3 moveDirection = targetDirection.normalized;
        Vector3 moveVector = moveDirection * 10f * Time.deltaTime;
        if (moveVector.sqrMagnitude > targetDirection.sqrMagnitude)
        {
            newPos = currentTarget;
        }
        else
        {
            newPos = transform.position + moveVector;
        }
        transform.position = newPos;
    }

    public void ChangeShark()
    {
        playersharks[sharkindex].SetActive(false);
    }
}
