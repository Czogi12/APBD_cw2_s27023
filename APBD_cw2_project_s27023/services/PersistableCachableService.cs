using APBD_cw2_project_s27023.modules;
using APBD_cw2_project_s27023.ropositories;

namespace APBD_cw2_project_s27023.services;

public abstract class PersistableCachableService<T, TE> : CachableService<T, TE>
    where TE : Identifiable<T>
{
    private readonly IRepository<TE> _repository;

    public PersistableCachableService(IRepository<TE> repository)
    {
        _repository = repository;
        
        if (!Directory.Exists("data"))
        {
            Directory.CreateDirectory("data");
        }
        
        foreach (var item in _repository.Load())
        {
           base.Add(item); 
        }
    }

    public PersistableCachableService(string fileName) : this(new GenericRepository<TE>(fileName))
    {
    }

    public override void Add(TE data)
    {
        base.Add(data);
        Save();
    }

    public override void Delete(T id)
    {
        base.Delete(id);
        Save();
    }

    public void Save()
    {
        _repository.Save(GetAll());
    }
}