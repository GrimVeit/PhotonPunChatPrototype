using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class CharacterRepository : Repository
    {
        public int PlayerID { get; private set; }

        private const string KEY_CHARACTER = "PLAYER_ID";

        public override void Initialize()
        {
            PlayerID = PlayerPrefs.GetInt(KEY_CHARACTER, 0);
        }

        public void SetData(int newID)
        {
            PlayerID = newID;
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY_CHARACTER, PlayerID);
        }
    }
}
