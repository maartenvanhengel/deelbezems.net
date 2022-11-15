namespace Htf2022.Deelbezems.Infrastructure;

public interface IBezemEventHandler
{
    Task Handle(string data, CancellationToken cancellationToken);
}