using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class ProfileStorage : MonoBehaviour
{
    public static ProfileData s_currentProfile;
    private static string s_indexPath = Application.streamingAssetsPath + "/Profiles/_ProfileIndex_.xml";
    public static void CreateNewGame(string profileName)
    {
        s_currentProfile = new ProfileData(profileName, true, 0, 0, 0);

        string path = Application.streamingAssetsPath + "/Profiles/" + s_currentProfile.filename;
        SaveFile<ProfileData>(path, s_currentProfile);

        var index = GetProfileIndex();
        index.profileFileNames.Add(s_currentProfile.filename);

        SaveFile<ProfileIndex>(s_indexPath, index);
    }

    public static ProfileIndex GetProfileIndex()
    {
        if(File.Exists(s_indexPath) == false)
        {
            return new ProfileIndex();
        }
        return LoadFile<ProfileIndex>(s_indexPath);
    }

    
    static void SaveFile<T>(string path, T data)
    {
        var profileWriter = new StreamWriter(path);
        var profileSerializer = new XmlSerializer(typeof(T));
        profileSerializer.Serialize(profileWriter, data);
        profileWriter.Dispose();
    }
    static T LoadFile<T>(string path)
    {
        var profileReader = new StreamReader(path);
        var serializer = new XmlSerializer(typeof(T));
        var obj = (T)serializer.Deserialize(profileReader);

        return obj;
    }
}
