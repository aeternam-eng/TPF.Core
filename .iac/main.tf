provider "azurerm" {
  subscription_id            = var.azurerm_provider_config.subscription_id
  client_id                  = var.azurerm_provider_config.client_id
  client_secret              = var.azurerm_provider_config.client_secret
  tenant_id                  = var.azurerm_provider_config.tenant_id
  skip_provider_registration = true

  features {}
}


terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0.0"
    }
  }

  // The storage account access key should be injected through pipeline env variables
  backend "azurerm" {}
}

resource "azurerm_resource_group" "rg" {
  name     = var.resource_group_config.name
  location = var.resource_group_config.location
}

resource "azurerm_service_plan" "appserviceplan" {
  name                = "asp-${var.service_config.name}-${var.service_config.short_env}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  os_type             = var.appserviceplan_config.os_type
  sku_name            = var.appserviceplan_config.sku_name
}

resource "azurerm_linux_web_app" "webapp" {
  name                = "${var.service_config.name}-${var.service_config.short_env}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  service_plan_id     = azurerm_service_plan.appserviceplan.id
  https_only          = true
  site_config {
    minimum_tls_version = "1.2"
    always_on           = false
  }
}

resource "azurerm_postgresql_flexible_server" "databaseserver" {
  name = "db-${var.service_config.name}-${var.service_config.short_env}"

  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location

  sku_name   = "B1_Standard_B1ms"
  version    = "14"
  storage_mb = 32768

  backup_retention_days = 7
}

resource "azurerm_storage_account" "storageaccount" {
  name                     = "satpfcore${var.service_config.short_env}"
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = azurerm_resource_group.rg.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_container" "storagecontainer" {
  name                  = "fire-images"
  storage_account_name  = azurerm_storage_account.storageaccount.name
  container_access_type = "blob"
}
