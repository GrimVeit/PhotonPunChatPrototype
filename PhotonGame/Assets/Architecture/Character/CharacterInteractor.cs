using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class CharacterInteractor : Interactor
    {
        public int PlayerID { get; private set; }

        private CharacterRepository characterRepository;
        private ICharacterSpawner characterSpawner;


        public override void Initialize()
        {
            base.Initialize();

            characterRepository = Game.GetRepository<CharacterRepository>();
            this.PlayerID = characterRepository.PlayerID;
        }

        public void SetSpawner(ICharacterSpawner characterSpawner)
        {
            this.characterSpawner = characterSpawner;
            this.characterSpawner.SetPlayer(PlayerID);
        }

        public void SpawnLocalCharacter()
        {
            if(characterSpawner == null)
            {
                Debug.Log("Не назначен спавнер");
                throw new System.Exception();
            }
            characterSpawner.SpawnLocalCharacter();
        }

        public void SpawnMultiplayerCharacter()
        {
            if (characterSpawner == null)
            {
                Debug.Log("Не назначен спавнер");
                throw new System.Exception();
            }
            characterSpawner.SpawnMultiplayerCharacter();
        }

        public void DestroyLocalCharacter()
        {
            if (characterSpawner == null)
            {
                Debug.Log("Не назначен спавнер");
                throw new System.Exception();
            }
            characterSpawner.DestroyLocalCharacter();
        }

        public void DestroyMultiplayerCharacter()
        {
            if (characterSpawner == null)
            {
                Debug.Log("Не назначен спавнер");
                throw new System.Exception();
            }
            characterSpawner.DestroyMultiplayerCharacter();
        }
    }
}
