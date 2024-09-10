namespace Foci;

public class Meccs {
    public Meccs(int forduloSzama, int hazaiGol, int vendegGol, int elsoFelidoGolok, int masodikFelidoGolok, string hazaiCsapatNeve, string vendegCsapatNeve) {
        ForduloSzama = forduloSzama;
        HazaiGol = hazaiGol;
        VendegGol = vendegGol;
        ElsoFelidoGolok = elsoFelidoGolok;
        MasodikFelidoGolok = masodikFelidoGolok;
        HazaiCsapatNeve = hazaiCsapatNeve;
        VendegCsapatNeve = vendegCsapatNeve;
    }

    public int ForduloSzama { get; set; }
    public int HazaiGol { get; set; }
    public int VendegGol { get; set; }
    public int ElsoFelidoGolok { get; set; }
    public int MasodikFelidoGolok { get; set; }
    public string HazaiCsapatNeve { get; set; }
    public string VendegCsapatNeve { get; set; }
}