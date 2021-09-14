using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ScoreTextScript : MonoBehaviour
    {

        public Text text;
        public static int coinCount = 0;

        public static void Save()
        {
            PlayerPrefs.SetInt(nameof(coinCount), coinCount);
        }

        public static void Load()
        {
            coinCount = PlayerPrefs.GetInt(nameof(coinCount), 0);
        }


        // Update is called once per frame
        void Update()
        {
            text.text = coinCount.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object other)
        {
            return base.Equals(other);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}