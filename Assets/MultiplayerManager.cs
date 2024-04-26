using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerManager : MonoBehaviour
{
    int index = 0;
    [SerializeField] private List<GameObject> fighters = new List<GameObject>();
    private PlayerInputManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        index = 0;
        manager.playerPrefab = fighters[index];
    }

    public void SwitchNextCharacter(PlayerInput input)
    {
        index = 1;
        manager.playerPrefab = fighters[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
