using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShark : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 currentTarget = new Vector3(0, 0, 0);
    [SerializeField]
    LayerMask rayLayerMask_Floor;

    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    PlayerManager playerManager;
    Vector3 height = new Vector3(0, 0.5f, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PointAndClick();
        }
        Vector3 newPos = Vector3.zero;
        Vector3 targetDirection = currentTarget - transform.position;
        Vector3 moveDirection = targetDirection.normalized;
        Vector3 moveVector = moveDirection * speed * Time.deltaTime;
        if (moveVector.sqrMagnitude > targetDirection.sqrMagnitude)
        {
            newPos = currentTarget;
        }
        else
        {
            newPos = transform.position + moveVector;
        }
        transform.position = newPos;
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mackerel"))
        {
            Destroy(collision.gameObject);
            if (playerManager.playersharks[0].activeSelf) { gameManager.gwscore++; }
            if (playerManager.playersharks[1].activeSelf) { gameManager.hscore++; }
            if (playerManager.playersharks[2].activeSelf) { gameManager.mscore++; }
        }
    }
    void PointAndClick()
    {
        Vector2 touchPos = Input.mousePosition;
        Ray currentRay = Camera.main.ScreenPointToRay(touchPos);
        RaycastHit hit;
        if (Physics.Raycast(currentRay, out hit, 3000, rayLayerMask_Floor))
        {
            Moving(hit.point);
        }
    }
    void Moving(Vector3 newTarget)
    {
        currentTarget = newTarget + height;
    }
}