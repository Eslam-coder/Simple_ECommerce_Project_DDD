namespace E_Commerce.API.Products.Features.Commands
{
    public class UpdateProductCommand : CreateProductCommand
    {
        public Guid Id { get; set; }
    }
}
