using APBD_cw2_project_s27023.modules;

namespace APBD_cw2_project_s27023.services;

public interface IService<T, TE> where TE : Identifiable<T>
{
    TE? Get(T id);

    void Add(TE data);

    void Delete(T id);

    List<TE> GetAll();
}