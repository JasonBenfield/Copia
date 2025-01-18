namespace XTI_CopiaWebAppApi;

partial class CopiaAppApiBuilder
{
    partial void Configure()
    {
        source.ConfigureTemplate
        (
            template => template.ExcludeValueTemplates
            (
                (valueTempl, codeGen) =>
                {
                    if (codeGen == ApiCodeGenerators.Dotnet)
                    {
                        return valueTempl.DataType.Namespace?.StartsWith("XTI_Copia.Abstractions") == true;
                    }
                    return false;
                }
            )
        );
    }
}