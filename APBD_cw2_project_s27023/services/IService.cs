namespace APBD_cw2_project_s27023.services;

public interface IService<T, TE> where T : notnull
{
    TE? Get(T id);

    void Add(T id, TE data);

    void Delete(T id);

    List<TE> GetAll();
}