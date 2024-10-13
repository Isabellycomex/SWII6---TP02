using CustomsSystem.Models;

namespace CustomsSystem.Data.Repositories
{
    public class BillRepository
    {
        public List<BillOfLading> GetAllBills()
        {
            using var context = new CustomsContext();

            return [.. context.Bills];
        }

        public BillOfLading? GetBillById(int id)
        {
            using var context = new CustomsContext();

            return context.Bills.Single(b => b.Id == id);
        }

        public List<Container> GetAllContainersWithId(int id)
        {
            using var context = new CustomsContext();

            return context.Containers.Where(c => c.BillOfLadingId == id).ToList();
        }

        public void AddBill(BillOfLading bill)
        {
            using var context = new CustomsContext();

            context.Bills.Add(bill);

            context.SaveChanges();
        }

        public void UpdateBill(BillOfLading bill)
        {
            using var context = new CustomsContext();

            var entity = context.Bills.Single(b => b.Id == bill.Id);

            entity.Number = bill.Number;
            entity.Consignee = bill.Consignee;
            entity.Ship = bill.Ship;

            foreach (var container in bill.Containers)
            {
                entity.Containers.Add(container);
            }

            context.SaveChanges();
        }

        public void DeleteBill(int id)
        {
            using var context = new CustomsContext();

            var bill = context.Bills.Single(b => b.Id == id);

            context.Bills.Remove(bill);

            context.SaveChanges();
        }
    }
}
