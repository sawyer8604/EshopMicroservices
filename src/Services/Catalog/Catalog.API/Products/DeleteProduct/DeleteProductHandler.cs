namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProdductCommand(Guid Id) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProdductCommandValidator : AbstractValidator<DeleteProdductCommand>
    {
        public DeleteProdductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is Required");
        }
    }

    internal class DeleteProductCommandHandler
        (IDocumentSession session)
        : ICommandHandler<DeleteProdductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProdductCommand command, CancellationToken cancellationToken)
        {            
            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
