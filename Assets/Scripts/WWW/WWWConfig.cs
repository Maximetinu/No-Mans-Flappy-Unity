public static class WWWConfig{
    public static string host = "localhost";
    public static string directory = "php/game-scripts";

    public static string unblockByCommunityURL = "http://" + host + "/" + directory + "/unlock-by-community.php";
    public static string individualLimitURL = "http://" + host + "/" + directory + "/individual-limit.php";
    public static string highscoreURL = "http://" + host + "/" + directory + "/upload-highscore.php";
    public static string highscoreURL_B = "http://" + host + "/" + directory + "/upload-highscore-b-mode.php";
    public static string setHighscoresInactivesURL = "http://" + host + "/" + directory + "/set-highscores-inactives.php";

    public static string gameName = "FlapyWheel";
    public static string hashKey = "MiLlaveSecreta";
}
