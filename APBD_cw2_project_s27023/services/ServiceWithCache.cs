namespace APBD_cw2_project_s27023.services;

public abstract class ServiceWithCache<T, TE> : IService<T, TE> where T : notnull
{
    private Dictionary<T, TE> Cache { get; } = new();

    public TE? Get(T id)
    {
        return Cache.ContainsKey(id) ? Cache[id] : default;
    }

    public void Add(T id, TE data)
    {
        if (Cache.ContainsKey(id) || Cache.ContainsValue(data)) return;

        Cache.Add(id, data);
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