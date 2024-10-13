using CustomsSystem.Models;

namespace CustomsSystem.Data.Repositories
{
    public class ContainerRepository
    {
        public List<Container> GetAllContainers()
        {
            using var context = new CustomsContext();

            return [.. context.Containers];
        }

        public Container? GetContainerById(int id)
        {
            using var context = new CustomsContext();

            return context.Containers.Single(c => c.Id == id);
        }

        public void AddContainer(Container container)
        {
            using var context = new CustomsContext();

            context.Containers.Add(container);

            context.SaveChanges();
        }

        public void UpdateContainer(Container container)
        {
            using var context = new CustomsContext();

            var entity = context.Containers.Single(c => c.Id == container.Id);

            entity.Number = container.Number;
            entity.Type = container.Type;
            entity.Size = container.Size;

            context.SaveChanges();
        }

        public void DeleteContainer(int id)
        {
            using var context = new CustomsContext();

            var container = context.Containers.Single(c => c.Id == id);

            context.Containers.Remove(container);

            context.SaveChanges();
        }
    }
}
