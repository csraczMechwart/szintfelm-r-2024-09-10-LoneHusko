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
        
        var forditottEredmenyek = meccsek.Where(meccs => 
                (meccs.ElsoFelidoHazaiGolok < meccs.ElsoFelidoVendegGolok && meccs.HazaiGol > meccs.VendegGol) 
                || 
                (meccs.ElsoFelidoVendegGolok < meccs.ElsoFelidoHazaiGolok && meccs.VendegGol > meccs.HazaiGol)
            )
            .Select(meccs => new 
            { 
                forduloSzama = meccs.ForduloSzama, 
                nyertesCsapat = meccs.HazaiGol > meccs.VendegGol ? meccs.HazaiCsapatNeve : meccs.VendegCsapatNeve 
            })
            .ToList();
        Console.WriteLine("\n2. félidőben fordított meccsek:");
        foreach (var result in forditottEredmenyek) {
            Console.WriteLine($"{result.forduloSzama}.: {result.nyertesCsapat}");
        }
    }
}