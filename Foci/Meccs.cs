namespace Foci;

public class Meccs {
    public Meccs(int forduloSzama, int hazaiGol, int vendegGol, int elsoFelidoHazaiGolok, int elsoFelidoVendegGolok, string hazaiCsapatNeve, string vendegCsapatNeve) {
        ForduloSzama = forduloSzama;
        HazaiGol = hazaiGol;
        VendegGol = vendegGol;
        ElsoFelidoHazaiGolok = elsoFelidoHazaiGolok;
        ElsoFelidoVendegGolok = elsoFelidoVendegGolok;
        HazaiCsapatNeve = hazaiCsapatNeve;
        VendegCsapatNeve = vendegCsapatNeve;
    }

    public int ForduloSzama { get; set; }
    public int HazaiGol { get; set; }
    public int VendegGol { get; set; }
    public int ElsoFelidoHazaiGolok { get; set; }
    public int ElsoFelidoVendegGolok { get; set; }
    public string HazaiCsapatNeve { get; set; }
    public string VendegCsapatNeve { get; set; }
}