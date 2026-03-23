namespace APBD_cw2_project_s27023.ropositories;

// Not really a repository in quering data, but still acts as a bridge between db(json in filesystem)
public interface IRepository<T>
{
    List<T> Load();
    void Save(List<T> list);
}