namespace APBD_cw2_project_s27023.services;

public interface ICountableService<T>
{
    public int Count();
    public int Count(T e);
}