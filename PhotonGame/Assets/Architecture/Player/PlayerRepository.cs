using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class PlayerRepository : Repository
    {
        public string PlayerName { get; private set; }
        public Color PlayerNameColor { get; private set; }

        private const string KEY_NAME_COLOR = "PLAYER_NAME_COLOR";
        private const string KEY_NAME = "PLAYER_NAME";

        public override void Initialize()
        {
            Debug.Log(PlayerPrefs.GetString(KEY_NAME_COLOR));
            if(!ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString(KEY_NAME_COLOR), out Color color))
            {
                color = Color.white;
            }
            PlayerName = PlayerPrefs.GetString(KEY_NAME, "Игрок");
            PlayerNameColor = color;
            Debug.Log(PlayerName);
            Debug.Log(PlayerNameColor.ToString());
        }

        public void SetName(object sender, string playerName)
        {
            PlayerName = playerName;
            Debug.Log(playerName);
            PlayerPrefs.SetString(KEY_NAME, playerName);
        }

        public void SetColor(object sender, Color color)
        {
            PlayerNameColor = color;
            Debug.Log(color.ToString());
            PlayerPrefs.SetString(KEY_NAME_COLOR, ColorUtility.ToHtmlStringRGBA(color));
        }

        public override void Save()
        {

        }
    }
}
