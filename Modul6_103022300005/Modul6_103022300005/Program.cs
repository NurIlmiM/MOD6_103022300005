using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    { 
        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.title = title; 
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 10000000)
        {
            throw new ArgumentOutOfRangeException("Jumlah play count harus antara 1 - 10.000.000");
        }

        checked
        {
            playCount += count;
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }

    public int GetPlayCount()
    {
        return playCount;
    }
}

class SayaTubeUser
{
    private int id;
    private string username;
    private List<SayaTubeVideo> uploadVideos;

    public SayaTubeUser(string username)
    {
        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.username = username;
        this.uploadVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null)
        {
            throw new ArgumentNullException("Video tidak boleh null!");
        }
        uploadVideos.Add(video);
    }

    public int GetTotalVideoPlayCount()
    {
        int totalPlayCount = 0;
        foreach (var video in uploadVideos)
        {
            totalPlayCount += video.GetPlayCount();
        }
        return totalPlayCount;
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("User: " + username);
        int index = 1;
        foreach (var video in uploadVideos)
        {
            Console.WriteLine("video {index}judul: {video.GetTitle()");
            index++;
        }
    }
}

class Program
{
    static void Main()
    {
        SayaTubeUser user = new SayaTubeUser("Nur Ilmi Mufidah");

        SayaTubeVideo video1 = new SayaTubeVideo("Review Film Moana oleh Nur Ilmi Mufidah");
        SayaTubeVideo video2 = new SayaTubeVideo("Review Film Delisa oleh Nur Ilmi Mufidah");
        SayaTubeVideo video3 = new SayaTubeVideo("Review Film negeri 5 menara oleh Nur Ilmi Mufidah");
        SayaTubeVideo video4 = new SayaTubeVideo("Review Film Jembatan Pensil oleh Nur Ilmi Mufidah");
        SayaTubeVideo video5 = new SayaTubeVideo("Review Film Moana oleh Nur Ilmi Mufidah");
        SayaTubeVideo video6 = new SayaTubeVideo("Review Film Moana oleh Nur Ilmi Mufidah");
        SayaTubeVideo video7 = new SayaTubeVideo("Review Film Moana oleh Nur Ilmi Mufidah");
        SayaTubeVideo video8 = new SayaTubeVideo("Review Film Moana oleh Nur Ilmi Mufidah");
        SayaTubeVideo video9 = new SayaTubeVideo("Review Film Moana oleh Nur Ilmi Mufidah");
        SayaTubeVideo video10 = new SayaTubeVideo("Review Film Moana oleh Nur Ilmi Mufidah");

        user.AddVideo(video1);
        user.AddVideo(video2);
        user.AddVideo(video3);
        user.AddVideo(video4);
        user.AddVideo(video5);
        user.AddVideo(video6);
        user.AddVideo(video7);
        user.AddVideo(video8);
        user.AddVideo(video9);
        user.AddVideo(video10);

        video1.IncreasePlayCount(5000);
        video2.IncreasePlayCount(7000);
        video3.IncreasePlayCount(8000);
        video4.IncreasePlayCount(9000);
        video5.IncreasePlayCount(10000);

        Console.WriteLine("Detail Video: ");
        video1.PrintVideoDetails();

        Console.WriteLine("\nTotal Play Count: " + user.GetTotalVideoPlayCount());

        Console.WriteLine("\nDaftar Video: ");
        user.PrintAllVideoPlaycount();
    }
}
