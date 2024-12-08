using System;
using UnityEngine;


namespace Enemy
{
    public class EnemyState : MonoBehaviour
    {
        private float CurrentTrackProgression;
        private int TrackLenght;

        public static event Action<GameObject> EndReached;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (CurrentTrackProgression > TrackLenght)
            {
                EndReached?.Invoke(gameObject); 
            }
        }
    }
}