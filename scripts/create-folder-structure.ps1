# Define the root directory for the Helix project
$rootPath = "C:\ScAcademy\src"

# Define the layers and example modules
$layers = @{
    Foundation = @("Serialization");
    Feature = @("Navigation");
    Project = @("website")
}

# Function to create the Helix folder structure
function Create-HelixStructure {
    param (
        [string]$rootPath,
        [hashtable]$layers
    )

    foreach ($layer in $layers.Keys) {
        $layerPath = Join-Path $rootPath $layer
        New-Item -Path $layerPath -ItemType Directory -Force

        foreach ($module in $layers[$layer]) {
            $modulePath = Join-Path $layerPath $module
            New-Item -Path $modulePath -ItemType Directory -Force

            # Create "code" and "items" folders for each module
            $codePath = Join-Path $modulePath "code"
            New-Item -Path $codePath -ItemType Directory -Force

            $itemsPath = Join-Path $modulePath "items"
            New-Item -Path $itemsPath -ItemType Directory -Force

            # Add specific subfolders under "code" for Feature and Project layers
            if ($layer -eq "Feature") {
                New-Item -Path (Join-Path $codePath "App_Config\Include") -ItemType Directory -Force
                New-Item -Path (Join-Path $codePath "Views") -ItemType Directory -Force
            } elseif ($layer -eq "Project") {
                New-Item -Path (Join-Path $codePath "App_Config\Include") -ItemType Directory -Force
                New-Item -Path (Join-Path $codePath "Views") -ItemType Directory -Force
                New-Item -Path (Join-Path $codePath "css") -ItemType Directory -Force
                New-Item -Path (Join-Path $codePath "fonts") -ItemType Directory -Force
                New-Item -Path (Join-Path $codePath "js") -ItemType Directory -Force
                New-Item -Path (Join-Path $codePath "layouts") -ItemType Directory -Force
            }
        }
    }
}

# Create the folder structure
Write-Host "Creating Helix folder structure at: $rootPath"
Create-HelixStructure -rootPath $rootPath -layers $layers

Write-Host "Helix folder structure created successfully!"

