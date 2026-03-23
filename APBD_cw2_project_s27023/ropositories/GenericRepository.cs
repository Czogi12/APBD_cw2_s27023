using System.Text.Json;

namespace APBD_cw2_project_s27023.ropositories;

public class GenericRepository<T>(string fileName) : IRepository<T>
{
    public List<T> Load()
    {
        if (!File.Exists($"data/{fileName}.json")) return [];
        var json = File.ReadAllText($"data/{fileName}.json");
        return JsonSerializer.Deserialize<List<T>>(json) ?? [];
    }

    public void Save(List<T> list)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(list, options);
        File.WriteAllText($"data/{fileName}.json", json);
    }
}