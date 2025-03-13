# Define the site name in Sitecore
$siteName = "ScAcademy"

# Function to create a folder if it doesn't already exist
function Create-SitecoreFolder {
    param (
        [string]$path,
        [string]$folderName
    )
    $fullPath = Join-Path $path $folderName
    if (-not (Test-Path $fullPath)) {
        New-Item -Path $path -Name $folderName -ItemType "Common/Folder" | Out-Null
        Write-Host "Created folder: $fullPath"
    } else {
        Write-Host "Folder already exists: $fullPath"
    }
}

# Templates
Write-Host "Creating templates folder structure..."
Create-SitecoreFolder -path "/sitecore/templates/Foundation" -folderName $siteName
Create-SitecoreFolder -path "/sitecore/templates/Feature" -folderName $siteName
Create-SitecoreFolder -path "/sitecore/templates/Project" -folderName $siteName


# Media Library
Write-Host "Creating media library folder structure..."
Create-SitecoreFolder -path "/sitecore/media library/Project" -folderName $siteName


# Layouts
Write-Host "Creating layout folder structure..."
Create-SitecoreFolder -path "/sitecore/layout/Layouts/Project" -folderName $siteName
Create-SitecoreFolder -path "/sitecore/layout/Renderings/Project" -folderName $siteName
Create-SitecoreFolder -path "/sitecore/layout/Placeholder Settings/Project" -folderName $siteName



Write-Host "Sitecore folder structure created successfully for site: $siteName!"
