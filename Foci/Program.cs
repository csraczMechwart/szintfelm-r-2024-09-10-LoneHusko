namespace Foci;

class Program {
    static void Main(string[] args) {
        List<Meccs> meccsek = Foci.FileManager.Beolvas();
        Console.WriteLine("Forduló száma:");
        var forduloSzama = Convert.ToInt32(Console.ReadLine());
        List<Meccs> keres = meccsek.Where(meccs => meccs.ForduloSzama == forduloSzama).ToList();
        foreach (var meccs in keres) {
            Console.WriteLine($"{meccs.HazaiCsapatNeve}-{meccs.VendegCsapatNeve}: {meccs.HazaiGol}-{meccs.VendegGol} ({meccs.ElsoFelidoHazaiGolok}-{meccs.ElsoFelidoVendegGolok})");
        }
    }
}