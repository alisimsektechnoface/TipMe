namespace Application.Features.Invoices.Constants;

public static class InvoicesOperationClaims
{
    public const string Admin = "Invoices.Admin";

    public const string Read = "Invoices.Read";
    public const string Write = "Invoices.Write";

    public const string Create = "Invoices.Create";
    public const string Update = "Invoices.Update";
    public const string Delete = "Invoices.Delete";
    public const string GenerateInvoice = "Invoices.GenerateInvoice";
    public const string GetByQrCode = "Invoices.GetByQrCode";
    public const string QrCodeGenerate = "Invoices.QrCodeGenerate";
    public const string GetAdditionByQrCode = "Invoices.GetAdditionByQrCode";
}
