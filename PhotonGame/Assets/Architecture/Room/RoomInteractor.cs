using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class RoomInteractor : Interactor
    {
        private IRoomSpawner spawner;

        public void SetSpawner(IRoomSpawner roomSpawner)
        {
            spawner = roomSpawner;
        }

        public void SpawnRandomRoom()
        {
            spawner.RandomRoomSpawner();
        }
    }
}
