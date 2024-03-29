using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpTouch : MonoBehaviour, IPointerDownHandler
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        player.touchJump = true;
    }
}
