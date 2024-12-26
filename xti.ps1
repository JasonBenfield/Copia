Import-Module PowershellForXti -Force

function Xti-AddCopiaDBMigrations {
    param ([Parameter(Mandatory)]$Name)
    $env:DOTNET_ENVIRONMENT="Development"
    dotnet ef --startup-project ./CopiaWebApp/Internal/XTI_CopiaDbTool migrations add $Name --project ./CopiaWebApp/Internal/XTI_CopiaDB.SqlServer
}

function Xti-UpdateCopiaDb {
    param (
        [Parameter(ValueFromPipelineByPropertyName = $true)]
        [ValidateSet(“Development", "Production", "Staging", "Test")]
        $EnvName='Test'
    )
    dotnet run --environment $EnvName --project ./CopiaWebApp/Internal/XTI_CopiaDbTool --Command update
    if( $LASTEXITCODE -ne 0 ) {
        Throw "Update failed"
    }
}

function Xti-UpdateNpm {
	Start-Process -FilePath "cmd.exe" -WorkingDirectory CopiaWebApp/Apps/CopiaWebApp -ArgumentList "/c", "npm install @jasonbenfield/sharedwebapp@latest"
}