// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Linq.Expressions;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Debug.Assert(!string.IsNullOrEmpty(title), "title tidak boleh kosong");
        Debug.Assert(title.Length <= 100, "title tidak boleh lebih dari 100 karakter");

        Random randomId = new Random();
        this.id = randomId.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count <= 10000000, "Play Count maksimal 10.000.000 per panggilan method");

        try
        {
            checked
            {
                this.playCount += count;
            }
        }catch(OverflowException ex)
        {
            Console.WriteLine("[ERROR] Play count melebihi batas integer!");
            Console.WriteLine(ex.Message);
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("Play Count: " + this.playCount);
    }
}
class Program
{
    public static void Main()
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design by Contract - Rafa Mufid 'Aqila");
        video.PrintVideoDetails();

        try
        {
            SayaTubeVideo vidNull = new SayaTubeVideo(null);
        }catch(Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }

        try
        {
            SayaTubeVideo vidLen = new SayaTubeVideo(new string('w', 101));
        }catch(Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }

        try
        {
            video.IncreasePlayCount(10000001);
        }catch(Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }
    }
}
