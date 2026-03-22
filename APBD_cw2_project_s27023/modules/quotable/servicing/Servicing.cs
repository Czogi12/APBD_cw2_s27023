using APBD_cw2_project_s27023.exceptions;
using APBD_cw2_project_s27023.modules.quotable.rent;

namespace APBD_cw2_project_s27023.modules.quotable.servicing;

// This is created at the moment of equipment return.
// At this point receiver should inspect equipment, and if he finds anything should mark it for servicing.
// Equipment will be sent for servicing and after return available again for renting, and servicing price will be quoted to person who damaged it.
public class Servicing(long id, string description, Rent rent) : Quotable(id)
{
    public string Description { get; } = description;
    public Rent Rent { get; } = rent;
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