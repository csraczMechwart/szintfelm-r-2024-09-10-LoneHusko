using System.Reflection.Metadata.Ecma335;

namespace Foci;

public class FileManager {
    public static List<Meccs> Beolvas() {
        List<Meccs> meccsLista = new List<Meccs>();

        StreamReader sr = new StreamReader("Feladat/meccs.txt");
        var line = sr.ReadLine();

        while (line != null) {
            var adatok = line.Split(" ");
            if (adatok.Length == 7)
                meccsLista.Add(new Meccs(
                    Convert.ToInt32(adatok[0]), 
                    Convert.ToInt32(adatok[1]), 
                    Convert.ToInt32(adatok[2]), 
                    Convert.ToInt32(adatok[3]), 
                    Convert.ToInt32(adatok[4]), 
                    adatok[5], 
                    adatok[6]
                ));

            line = sr.ReadLine();
        }
        sr.Close();
        return meccsLista;
    }
}