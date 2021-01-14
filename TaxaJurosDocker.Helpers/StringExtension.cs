namespace TaxaJurosDocker.Helpers
{
    public static class StringExtension
    {
        public static string CampoRequerido(this string campo) => $"O campo [{campo}] é requerido.";
        public static string CampoInvalido(this string campo) => $"O campo [{campo}] é inválido.";
    }
}
