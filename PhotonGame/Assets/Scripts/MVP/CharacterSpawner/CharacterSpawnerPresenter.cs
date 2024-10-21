using System;

public class CharacterSpawnerPresenter
{
    private CharacterSpawnerModel characterSpawnerModel;
    private CharacterSpawnerView characterSpawnerView;

    public CharacterSpawnerPresenter(CharacterSpawnerModel characterSpawnerModel, CharacterSpawnerView characterSpawnerView)
    {
        this.characterSpawnerModel = characterSpawnerModel;
        this.characterSpawnerView = characterSpawnerView;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {

    }

    private void DeactivateEvents()
    {

    }

    #region Input

    public event Action<Character> OnSpawnCharacter
    {
        add { characterSpawnerModel.OnSpawnCharacter += value; }
        remove { characterSpawnerModel.OnSpawnCharacter -= value; }
    }

    public event Action OnDestroyCharacter
    {
        add { characterSpawnerModel.OnDestroyCharacter += value; }
        remove { characterSpawnerModel.OnDestroyCharacter -= value; }
    }

    public void SpawnLocalCharacter()
    {
        characterSpawnerModel.SpawnLocalCharacter();
    }

    public void SpawnMultiplayerCharacter()
    {
        characterSpawnerModel.SpawnLocalCharacter();
    }

    public void DestroyLocalCharacter()
    {
        characterSpawnerModel.DestroyLocalCharacter();
    }

    public void DestroyMultiplayerCharacter()
    {
        characterSpawnerModel.DestroyMultiplayerCharacter();
    }

    #endregion
}
