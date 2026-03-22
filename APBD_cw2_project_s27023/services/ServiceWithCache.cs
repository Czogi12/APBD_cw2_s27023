using APBD_cw2_project_s27023.modules;

namespace APBD_cw2_project_s27023.services;

public abstract class ServiceWithCache<T, TE> : IService<T, TE> where TE : Identifiable<T>
{
    private Dictionary<T, TE> Cache { get; } = new();

    public TE? GetOrDefault(T id)
    {
        return Cache.ContainsKey(id) ? Cache[id] : default;
    }

    public abstract TE Get(T id);

    public void Add(TE data)
    {
        if (Cache.ContainsKey(data.Id) || Cache.ContainsValue(data)) return;
        Cache.Add(data.Id, data);
    }

    public void Delete(T id)
    {
        Cache.Remove(id);
    }

    public List<TE> GetAll()
    {
        return Cache.Values.ToList();
    }
}