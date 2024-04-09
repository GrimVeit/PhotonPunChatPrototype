using Photon.Pun.Demo.Cockpit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnChangedName(string name);
public delegate void OnChangedNameColor(Color color);

namespace Lessons.Architecture
{
    public class PlayerInteractor : Interactor
    {
        public event OnChangedName onChangedName;
        public event OnChangedNameColor onChangedNameColor;

        public string PlayerName { get; private set; }
        public Color PlayerNameColor { get; private set; }



        private PlayerRepository playerRepository;

        public override void OnCreate()
        {
            base.OnCreate();
            playerRepository = Game.GetRepository<PlayerRepository>();
        }

        public override void Initialize()
        {
            base.Initialize();

            playerRepository = Game.GetRepository<PlayerRepository>();
        }

        public override void OnStart()
        {
            base.OnStart();

            PlayerName = playerRepository.PlayerName;
            PlayerNameColor = playerRepository.PlayerNameColor;

            //Debug.Log(PlayerName);
            //Debug.Log(PlayerNameColor);
        }

        public void SetName(object sender, string name)
        {
            onChangedName?.Invoke(name);
            PlayerName = name;
            playerRepository.SetName(this, name);
        }

        public void SetColor(object sender, Color color)
        {
            onChangedNameColor?.Invoke(color);
            PlayerNameColor = color;
            playerRepository.SetColor(this, color);
        }

        public void SaveData()
        {
            playerRepository.Save();
        }
    }
}
