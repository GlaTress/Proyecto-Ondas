using UnityEngine;

public class ProfileSpawner : MonoBehaviour
{
    public Transform newGameSpawn;
    public GameObject PlayerPrefab;

    private void Start()
    {
        if(ProfileStorage.s_currentProfile == null || ProfileStorage.s_currentProfile.newGame)
        {
            Instantiate(this.PlayerPrefab, this.newGameSpawn.position, Quaternion.identity);
        }
        else
        {
            float x = ProfileStorage.s_currentProfile.x;
            float y = ProfileStorage.s_currentProfile.y;
            float z = ProfileStorage.s_currentProfile.z;

            Vector3 pos = new Vector3(x, y, z);

            Instantiate(this.PlayerPrefab, pos, Quaternion.identity);
        }
    }
}
