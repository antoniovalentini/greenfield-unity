using UnityEngine;
using Zenject;

namespace AValentini.Helpers.Async
{
    public class TestHotKeysAdder : ITickable
    {
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Hotkey triggered!");
            }
        }
    }
}