public static class Events
{
    public static SimpleEvent<int, int> CrystalCollected = new SimpleEvent<int, int>();
    public static SimpleEvent<bool> ExitOpen = new SimpleEvent<bool>();
    public static SimpleEvent<int> TotalDeaths = new SimpleEvent<int>();
    public static SimpleEvent<int> LevelDeaths = new SimpleEvent<int>();
    public static SimpleEvent<bool> GameStarted = new SimpleEvent<bool>();
}
