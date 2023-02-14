using SuperBowl;
using System.Text;


List<Donto> dontok = new();
using StreamReader sr = new("..\\..\\..\\src\\SuperBowl.txt", Encoding.UTF8);
_ = sr.ReadLine()!;
while (!sr.EndOfStream) dontok.Add(new Donto(sr.ReadLine()!));

Console.WriteLine($"4. feladat: Döntők száma: {dontok.Count}");

double f5 = dontok.Average(x => x.Eredmeny.GY - x.Eredmeny.V);
Console.WriteLine($"5. feladat: Átlagos pontkülönbség: {f5:0.0}");

Donto f6 = dontok.OrderByDescending(x => x.Nezoszam).First();
Console.WriteLine("6. feladat: Legmagasabb nézőszám a döntők során:\n" +
    $"\tSorszám (dátum): {f6.Ssz.ArabSsz} ({f6.Datum:yyyy.MM.dd.})\n" +
    $"\tGyőztes csapat: {f6.Gyoztes}, szerzett pontok: {f6.Eredmeny.GY}\n" +
    $"\tVesztes csapat: {f6.Vesztes}, szerzett pontok: {f6.Eredmeny.V}\n" +
    $"\tHelszszín: {f6.Helyszin}\n" +
    $"\tVáros, állam: {f6.Varos}, {f6.Allam}\n" +
    $"\tNézőszám: {f6.Nezoszam}");


//7. feladat:

Dictionary<string, int> f7dic = new();
foreach (Donto d in dontok)
{
    if (!f7dic.ContainsKey(d.Gyoztes)) f7dic.Add(d.Gyoztes, 1);
    else f7dic[d.Gyoztes]++;
    if (!f7dic.ContainsKey(d.Vesztes)) f7dic.Add(d.Vesztes, 1);
    else f7dic[d.Vesztes]++;
}

using StreamWriter sw = new(path:"..\\..\\..\\src\\SuperBlowNew.txt", append:false, encoding:Encoding.UTF8);
sw.WriteLine("Ssz;Dátum;Győztes;Eredmény;Vesztes;Nézőszám");
foreach (Donto d in dontok)
{
    string p0 = d.Ssz.ArabSsz;
    string p1 = d.Datum.ToString("yyyy.MM.dd.");
    string p2 = $"{d.Gyoztes} ({f7dic[d.Gyoztes]})";
    string p3 = $"{d.Eredmeny.GY}-{d.Eredmeny.V}";
    string p4 = $"{d.Vesztes} ({f7dic[d.Vesztes]})";
    string p5 = $"{d.Nezoszam}";

    sw.WriteLine($"{p0};{p1};{p2};{p3};{p4};{p5}");
}

