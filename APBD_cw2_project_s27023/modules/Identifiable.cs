namespace APBD_cw2_project_s27023.modules;

public abstract class Identifiable<T>(T id)
{
    public T Id { get; } = id;
}