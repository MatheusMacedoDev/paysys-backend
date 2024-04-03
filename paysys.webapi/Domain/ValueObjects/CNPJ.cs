using Flunt.Validations;
using paysys.webapi.Utils;

namespace paysys.webapi.Domain.ValueObjects;

public class CNPJ : ValueObject
{
    public string? CNPJText { get; init; }

    protected CNPJ()
    {
    }

    public CNPJ(string cnpjText)
    {
        cnpjText = StringFormatter.FullyClear(cnpjText);

        AddNotifications(new Contract<CNPJ>()
            .IsNotNullOrEmpty(cnpjText, "CNPJ", "O CNPJ não pode ser nulo ou vazio")
            .Matches(cnpjText, @"^\d{14}$", "CNPJ", "CNPJ inválido")
        );

        if (!IsValid)
            throw new ArgumentException("CNPJ inválido");

        CNPJText = cnpjText;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CNPJText!;
    }
}
