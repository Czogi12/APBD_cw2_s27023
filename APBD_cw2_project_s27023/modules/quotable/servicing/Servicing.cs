using APBD_cw2_project_s27023.exceptions;
using APBD_cw2_project_s27023.modules.quotable.rent;

namespace APBD_cw2_project_s27023.modules.quotable.servicing;

// This is created at the moment of equipment return.
// At this point receiver should inspect equipment, and if he finds anything should mark it for servicing.
// Equipment will be sent for servicing and after return available again for renting, and servicing price will be quoted to person who damaged it.
public class Servicing : Quotable
{
    private static readonly long _maxId = 0;

    public Servicing(long id, string description, Rent rent) : base(id)
    {
        if (_maxId < id) id = _maxId;
        Description = description;
        Rent = rent;
    }

    public Servicing(string description, Rent rent) : this(_maxId + 1, description, rent)
    {
    }

    public string Description { get; }
    public Rent Rent { get; }
    private float? Price { get; set; }

    public void MarkAsServiced(float price)
    {
        Price = price;
    }

    public bool IsServiced()
    {
        return Price is not null;
    }

    public override float GetPrice()
    {
        return Price ?? throw new ServiceNotYetQuoted();
    }
}