public class ProfileData
{
    public string filename;
    public string name;
    public bool newGame;

    public float x;
    public float y;
    public float z;

    public ProfileData()
    {
        this.filename = "None.xml";
        this.name = "None";
        this.newGame = false;

        this.y = this.x = this.z = 0;
    }

    public ProfileData(string name, bool newGame, float x, float y, float z)
    {
        this.filename = name.Replace(" ", "_") + ".xml";
        this.name = name;
        this.newGame = newGame;
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
