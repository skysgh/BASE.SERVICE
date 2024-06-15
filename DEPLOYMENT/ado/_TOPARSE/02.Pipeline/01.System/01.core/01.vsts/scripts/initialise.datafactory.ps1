#help https://github.com/Azure/azure-cosmosdb-dotnet/blob/d3f8e9c731bc92816d023719e7e780b7a9546ca2/samples/rest-from-.net/Program.cs#L151-L164
param (
    # fill the target cosmos database endpoint uri and masterkey
    [string]$microsoftCosmoDbKey = "",
    [string]$microsoftCosmoDbName = "nzmoebaseatDataFactory",
    [string]$microsoftCosmoDbDatabaseName = "dataFactory",
    [string]$microsoftCosmoDbDatabaseCollectionName = "syncData",
    [int] $microsoftCosmoDbDatabaseCollectionScale = 1000 
)

Write-Host $microsoftCosmoDbName
Write-Host $microsoftCosmoDbDatabaseName
Write-Host $microsoftCosmoDbDatabaseCollectionName
Write-Host $microsoftCosmoDbDatabaseCollectionScale
$CosmosDBEndPoint = [string]::Format("https://{0}.documents.azure.com:443/", $microsoftCosmoDbName)
Write-Host $CosmosDBEndPoint
Write-Host $microsoftCosmoDbKey
# add necessary assembly
#
Add-Type -AssemblyName System.Web

# generate authorization key
Function Generate-MasterKeyAuthorizationSignature {
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory = $true)][String]$verb,
        [Parameter(Mandatory = $true)][String]$resourceLink,
        [Parameter(Mandatory = $true)][String]$resourceType,
        [Parameter(Mandatory = $true)][String]$dateTime,
        [Parameter(Mandatory = $true)][String]$key,
        [Parameter(Mandatory = $true)][String]$keyType,
        [Parameter(Mandatory = $true)][String]$tokenVersion
    )

    $hmacSha256 = New-Object System.Security.Cryptography.HMACSHA256
    $hmacSha256.Key = [System.Convert]::FromBase64String($key)

    If ($resourceLink -eq $resourceType) {
        $resourceLink = ""
    }

    $payLoad = "$($verb.ToLowerInvariant())`n$($resourceType.ToLowerInvariant())`n$resourceLink`n$($dateTime.ToLowerInvariant())`n`n"
    $hashPayLoad = $hmacSha256.ComputeHash([System.Text.Encoding]::UTF8.GetBytes($payLoad))
    $signature = [System.Convert]::ToBase64String($hashPayLoad);

    [System.Web.HttpUtility]::UrlEncode("type=$keyType&ver=$tokenVersion&sig=$signature")
}

# query
Function List-CosmosDb {
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory = $true)][String]$EndPoint,
        [Parameter(Mandatory = $true)][String]$MasterKey
    )

    $Verb = "GET"
    $ResourceType = "dbs";
    $ResourceLink = "dbs"

    $dateTime = [DateTime]::UtcNow.ToString("r")
    $authHeader = Generate-MasterKeyAuthorizationSignature -verb $Verb -resourceLink $ResourceLink -resourceType $ResourceType -key $MasterKey -keyType "master" -tokenVersion "1.0" -dateTime $dateTime
    $header = @{authorization = $authHeader; "x-ms-documentdb-isquery" = "True"; "x-ms-version" = "2017-02-22"; "x-ms-date" = $dateTime}
    $contentType = "application/query+json"
    $queryUri = [string]::Format("{0}{1}", $EndPoint, $ResourceLink)

    $result = Invoke-RestMethod -Method $Verb -ContentType $contentType -Uri $queryUri -Headers $header

    $result | ConvertTo-Json -Depth 2
    return ($result)
}

Function Create-CosmosDb {
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory = $true)][String]$EndPoint,
        [Parameter(Mandatory = $true)][String]$MasterKey
    )

    $Verb = "POST"
    $ResourceType = "dbs";
    $ResourceLink = "dbs"

    $dateTime = [DateTime]::UtcNow.ToString("r")
    $authHeader = Generate-MasterKeyAuthorizationSignature -verb $Verb -resourceLink $ResourceLink -resourceType $ResourceType -key $MasterKey -keyType "master" -tokenVersion "1.0" -dateTime $dateTime
    $header = @{authorization = $authHeader; "x-ms-documentdb-isquery" = "True"; "x-ms-version" = "2017-02-22"; "x-ms-date" = $dateTime}
    $contentType = "application/json"
    $queryUri = [string]::Format("{0}{1}", $EndPoint, $ResourceLink)
 
    Write-Host $queryUri
    $body = @{
        id = $microsoftCosmoDbDatabaseName
    }
    
    Write-Host $queryUri
    $result = Invoke-RestMethod -Method $Verb -ContentType $contentType -Uri $queryUri -Headers $header -Body ($body|ConvertTo-Json)
    return $result
}

# query
Function List-CosmosDbCollections {
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory = $true)][String]$EndPoint,
        [Parameter(Mandatory = $true)][String]$MasterKey
    )

    $Verb = "GET"
    $ResourceType = "colls";
    $ResourceLink = [string]::Format("dbs/{0}", $microsoftCosmoDbDatabaseName)
    Write-Host $ResourceLink

    $dateTime = [DateTime]::UtcNow.ToString("r")
    $authHeader = Generate-MasterKeyAuthorizationSignature -verb $Verb -resourceLink $ResourceLink -resourceType $ResourceType -key $MasterKey -keyType "master" -tokenVersion "1.0" -dateTime $dateTime
    $header = @{authorization = $authHeader; "x-ms-documentdb-isquery" = "True"; "x-ms-version" = "2017-02-22"; "x-ms-date" = $dateTime}
    $contentType = "application/query+json"
    $queryUri = [string]::Format("{0}{1}/{2}", $EndPoint, $ResourceLink, $ResourceType)

    Write-Host $queryUri
    $result = Invoke-RestMethod -Method $Verb -ContentType $contentType -Uri $queryUri -Headers $header

    $result | ConvertTo-Json -Depth 2
    return ($result)
}

Function Create-CosmosDbCollections {
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory = $true)][String]$EndPoint,
        [Parameter(Mandatory = $true)][String]$MasterKey
    )

    $Verb = "POST"
    $ResourceType = "colls";
    $ResourceLink = [string]::Format("dbs/{0}", $microsoftCosmoDbDatabaseName)

		$dateTime = [DateTime]::UtcNow.ToString("r")
		# Generate a token:
		$authHeader = Generate-MasterKeyAuthorizationSignature -verb $Verb -resourceLink $ResourceLink -resourceType $ResourceType -key $MasterKey -keyType "master" -tokenVersion "1.0" -dateTime $dateTime
		
    $header = @{authorization = $authHeader; "x-ms-documentdb-isquery" = "True"; "x-ms-version" = "2017-02-22"; "x-ms-date" = $dateTime; "x-ms-offer-throughput" = $microsoftCosmoDbDatabaseCollectionScale}
    $contentType = "application/json"
    $queryUri = [string]::Format("{0}{1}/{2}", $EndPoint, $ResourceLink, $ResourceType)
 
    $body = @{
        id             = $microsoftCosmoDbDatabaseCollectionName;
        indexingPolicy = @{
            indexingMode  = "Consistent";
            automatic     = $true
            includedPaths = 
            @(
                @{
                    path    = "/*";
                    indexes = @(
                        @{
                            kind      = "Range";
                            dataType  = "Number";
                            precision = -1
                        },
                        @{
                            kind      = "Range";
                            dataType  = "String";
                            precision = -1
                        },
                        @{
                            kind     = "Spatial";
                            dataType = "Point";
                        }
                    ) 
                }
             
            )
        };
        partitionKey   = @{
            paths = @("/TableName");
            kind  = "hash"
        };
    }
    
    Write-Host $queryUri
    Write-Host ($body|ConvertTo-Json -Depth 10)
    $result = Invoke-RestMethod -Method $Verb -ContentType $contentType -Uri $queryUri -Headers $header -Body ($body|ConvertTo-Json -Depth 10)
    return $result
}



try { 
    $result = List-CosmosDb -EndPoint $CosmosDBEndPoint -MasterKey $microsoftCosmoDbKey
    $DbCheckExistsRequest = ($result.Databases)

    Write-Host $DbCheckExistsRequest
    if (-Not ($DbCheckExistsRequest.id -contains $microsoftCosmoDbDatabaseName)) {
        Write-Host "Creating Database"
        Create-CosmosDb -EndPoint $CosmosDBEndPoint -MasterKey $microsoftCosmoDbKey
    }
}
catch {
    $DbCheckExistsRequest = $_.Exception.Response 
    Write-Host $_.Exception
    Write-Host $DbCheckExistsRequest.StatusCode
    If ([int]$DbCheckExistsRequest.StatusCode -ne 404 ) {
        Write-Host "exiting"
        throw "Check Logs for what happened"
    }
}



try { 
    Write-Host "Executing the Collections now"
    $result = List-CosmosDbCollections -EndPoint $CosmosDBEndPoint -MasterKey $microsoftCosmoDbKey
    $DbCheckExistsRequest = ($result.DocumentCollections)
    if (-Not ($DbCheckExistsRequest.id -contains $microsoftCosmoDbDatabaseCollectionName)) {
        Write-Host "Creating Collection within Database"
        Create-CosmosDbCollections -EndPoint $CosmosDBEndPoint -MasterKey $microsoftCosmoDbKey

    }
    Write-Host $DbCheckExistsRequest
}
catch {
    $DbCheckExistsRequest = $_.Exception.Response 
    Write-Host $_.Exception
    Write-Host $DbCheckExistsRequest.StatusCode
    If ([int]$DbCheckExistsRequest.StatusCode -ne 404 ) {
        Write-Host "exiting"
        throw "Check Logs for what happened"
    }
}









