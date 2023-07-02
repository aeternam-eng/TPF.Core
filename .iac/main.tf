// Injected from pipeline
provider "azurerm" {
  features {}
}

terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0.0"
    }
  }

  // Injected from pipeline
  backend "azurerm" {}
}

module "conventions" {
  source      = "https://sastronzo.blob.core.windows.net/terraform-modules/naming-conventions.zip"
  environment = var.environment
  namespace   = var.namespace_name
  appName     = "core"
}

resource "azurerm_service_plan" "appserviceplan" {
  name                = module.conventions.app_config.app_service_plan_name
  location            = var.resource_location
  resource_group_name = module.conventions.resource_group_name
  os_type             = var.appserviceplan_config.os_type
  sku_name            = var.appserviceplan_config.sku_name
}

resource "azurerm_linux_web_app" "webapp" {
  name                = module.conventions.app_config.web_app_name
  location            = var.resource_location
  resource_group_name = module.conventions.resource_group_name
  service_plan_id     = azurerm_service_plan.appserviceplan.id
  https_only          = true

  site_config {
    minimum_tls_version = "1.2"
    always_on           = false
    application_stack {
      dotnet_version = "6.0"
    }
  }
}

resource "random_password" "adminpassword" {
  length  = 16
  special = true
}

resource "azurerm_postgresql_flexible_server" "databaseserver" {
  name = module.conventions.app_config.database_name

  resource_group_name = module.conventions.resource_group_name
  location            = var.resource_location

  sku_name   = "B_Standard_B1ms"
  version    = "13"
  storage_mb = 32768

  backup_retention_days = 7

  administrator_login    = "stronzo"
  administrator_password = random_password.adminpassword.result
  zone                   = "3"
}

resource "azurerm_storage_account" "storageaccount" {
  name                     = "satpfcore${var.environment}"
  resource_group_name      = module.conventions.resource_group_name
  location                 = var.resource_location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_container" "storagecontainer" {
  name                  = "fire-images"
  storage_account_name  = azurerm_storage_account.storageaccount.name
  container_access_type = "blob"
}
