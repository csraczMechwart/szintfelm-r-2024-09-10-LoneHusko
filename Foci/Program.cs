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
        
        Console.WriteLine("\nCsapat neve:");
        var csapatNeve = Console.ReadLine();
        
        var csapatStat = meccsek
            .SelectMany(meccs => new[] {
                new { Csapat = meccs.HazaiCsapatNeve, Adott = meccs.HazaiGol, Kapott = meccs.VendegGol },
                new { Csapat = meccs.VendegCsapatNeve, Adott = meccs.VendegGol, Kapott = meccs.HazaiGol }
            })
            .Where(eredmeny => eredmeny.Csapat == csapatNeve)
            .GroupBy(eredmeny => eredmeny.Csapat)
            .Select(group => new {
                OsszesAdott = group.Sum(x => x.Adott),
                OsszesKapott = group.Sum(x => x.Kapott)
            })
            .FirstOrDefault();
        Console.WriteLine(csapatStat != null?$"lőtt: {csapatStat.OsszesAdott} kapott: {csapatStat.OsszesKapott}":"Nincs találat");
        
        var elsoVesztettMeccs = meccsek
            .Where(meccs => meccs.HazaiCsapatNeve == csapatNeve && meccs.HazaiGol < meccs.VendegGol)
            .OrderBy(meccs => meccs.ForduloSzama)
            .Select(meccs => new 
            { 
                forduloSzama = meccs.ForduloSzama,
                nyertes = meccs.VendegCsapatNeve,
            })
            .First();

        Console.WriteLine(elsoVesztettMeccs != null?$"Első elvesztett meccs hazaiként: {elsoVesztettMeccs.forduloSzama}, nyertes csapat: {elsoVesztettMeccs.nyertes}":"A csapat otthon veretlen maradt");
        
    }
}