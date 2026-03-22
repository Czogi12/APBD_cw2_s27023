namespace APBD_cw2_project_s27023.modules.quotable;

public abstract class Quotable(long id) : Identifiable<long>(id)
{
    private bool _isPaidOff;

    public bool IsPaidOff
    {
        get => _isPaidOff;
        set
        {
            if (value) _isPaidOff = true;
        }
    }

    public abstract float GetPrice();
}