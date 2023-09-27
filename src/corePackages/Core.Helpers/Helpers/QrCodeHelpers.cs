namespace Core.Helpers.Helpers
{
    public static class QrCodeHelpers
    {
        public static string GenerateQrCode()
        {
            return Guid.NewGuid().ToString().ToUpper() + "-" + Guid.NewGuid().ToString().ToUpper();
        }
    }
}
